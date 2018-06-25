using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cyc.Order.Web.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly OrderDbContext _context;

        public ShoppingCartController(OrderDbContext context)
        {
            _context = context;
        }

        [Route("/api/ShoppingCart")]
        public async Task<IActionResult> Index()
        {
            ShoppingCartViewModel shoppingCart = await Cart();
            var resultModel = new ResultModel();
            resultModel.Code = 100;
            resultModel.Data = shoppingCart;
            return Json(resultModel);
        }

        // 更新购物车数量
        [Route("/api/ShoppingCart/Quantity")]
        [HttpPost]
        public async Task<IActionResult> Quantity(int id, int num = 1)
        {
            var entity = await _context.Carts.FindAsync(id);
            entity.UpdateTime = DateTime.Now;
            entity.Checked = true;
            entity.Num = num;

            await _context.SaveChangesAsync();

            return Json(new ResultModel { Code = 100, Message = "更新数量" });
        }

        // 选择购物车商品
        [Route("/api/ShoppingCart/CartGoodsSelected")]
        [HttpPost]
        public async Task<IActionResult> CartGoodsSelected(int id, bool checkedAll = false)
        {
            if (id > 0)
            {
                var entity = await _context.Carts.SingleOrDefaultAsync(c => c.Id == id);
                entity.Checked = !entity.Checked;
            }
            else
            {
                var entities = await _context.Carts.Where(c => c.ShopId == Sid).ToListAsync();
                foreach (var item in entities)
                {
                    item.Checked = checkedAll;
                }
            }

            await _context.SaveChangesAsync();

            return Json(new ResultModel { Code = 100, Message = "选择商品" });
        }

        // 删除商品
        [Route("/api/ShoppingCart/Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var entity = await _context.Carts.FindAsync(id);
            entity.Status = 1;
            entity.UpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();

            var result = new ResultModel
            {
                Code = 100,
                Message = "删除成功"
            };

            return Json(result);
        }

        // 加入购物车
        [Route("/api/ShoppingCart/AddCart")]
        [HttpPost]
        public async Task<IActionResult> AddCart(int? goodsId)
        {
            ResultModel model = new ResultModel();

            if (goodsId == null)
            {
                model.Code = 102;
                model.Message = "非法参数";

                return Json(model);
            }

            var entity = await _context.Carts
                .SingleOrDefaultAsync(c => c.GoodsId == goodsId && c.ShopId == Sid && c.Status == 0);
            if (entity != null)
            {
                entity.Num += 1;
                entity.Checked = true;
                entity.UpdateTime = DateTime.Now;
            }
            else
            {
                var cart = new Cart();
                cart.ShopId = Sid;
                cart.GoodsId = goodsId.Value;
                cart.Num = 1;
                cart.Status = 0;
                cart.Checked = true;
                cart.CreateTime = DateTime.Now;
                _context.Carts.Add(cart);
            }

            await _context.SaveChangesAsync();

            model.Code = 100;
            model.Message = "加入购物车成功";
            return Json(model);
        }

        //预下单
        [Route("/api/ShoppingCart/PreOrder")]
        [HttpPost]
        public async Task<IActionResult> PreOrder([FromBody] ProOrderViewModel model)
        {
            var carts = await GetCartGoods(model.cartIds);
            var goodsIds = carts.Select(c => c.GoodsId).ToArray();
            var priceList = await _context.GoodsPrices.Where(p => goodsIds.Contains(p.GoodsId)).ToListAsync();

            foreach (var item in carts)
            {
                var entity = priceList.FirstOrDefault(p => p.GoodsId == item.GoodsId && p.ShopId == item.ShopId && !p.IsDelete);
                if (entity != null)
                {
                    item.Price = entity.Price;
                    continue;
                }
                // 默认商品价格
                entity = priceList.FirstOrDefault(p => p.GoodsId == item.GoodsId && p.ShopId == 0);

                if (entity != null)
                {
                    item.Price = entity.Price;
                }
            }

            var now = DateTime.Now;

            OrderRecord order = new OrderRecord();
            order.ShopId = Sid;
            order.Status = 0;
            order.Num = carts.Sum(c => c.Num);
            order.TotalAmount = carts.Sum(c => c.Num * c.Price);
            order.PayPrice = order.TotalAmount;
            order.OrderDate = now;

            await _context.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in carts)
            {
                var orderGoods = new OrderRecordDetail
                {
                    OrderId = order.Id,
                    GoodsId = item.GoodsId,
                    Code = item.GoodsCode,
                    Name = item.GoodsName,
                    Img = item.GoodsImg,
                    Num = item.Num,
                    Price = item.Price,
                    AddDate = now
                };
                await _context.AddAsync(orderGoods);
            }

            await _context.SaveChangesAsync();

            var result = new ResultModel();
            result.Code = 100;
            result.Data = new { oid = order.Id };
            return Json(result);
        }

        private async Task<ShoppingCartViewModel> Cart()
        {
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel();
            var cartGoodsList = await GetCartGoods();
            // 获取所有商品Id
            var goodsIds = cartGoodsList.Select(g => g.GoodsId).ToArray();
            // 获取购物车中所有商品的价格
            var priceList = await _context.GoodsPrices.Where(p => goodsIds.Contains(p.GoodsId)).ToListAsync();

            foreach (var item in cartGoodsList)
            {
                var model = priceList.FirstOrDefault(p => p.GoodsId == item.GoodsId && p.ShopId == item.ShopId && !p.IsDelete);
                if (model != null)
                {
                    item.Price = model.Price;
                    continue;
                }

                model = priceList.FirstOrDefault(p => p.GoodsId == item.GoodsId && p.ShopId == 0);

                if (model != null)
                {
                    item.Price = model.Price;
                }
            }

            viewModel.ShoppingCartGoodsModels = cartGoodsList;
            viewModel.AmountSum = cartGoodsList.Where(c => c.Checked).Sum(c => c.Num);
            viewModel.PriceSum = cartGoodsList.Where(c => c.Checked).Sum(c => c.Num * c.Price);
            var goodsSum = cartGoodsList.Sum(c => c.Num);
            if (goodsSum == viewModel.AmountSum)
            {
                viewModel.CheckedAll = true;
            }

            return viewModel;
        }


        //获取购物车所有商品
        private async Task<List<ShoppingCartGoodsModel>> GetCartGoods(int[] cartIds = null)
        {
            var query = from c in _context.Carts
                        join g in _context.Goods on c.GoodsId equals g.Id
                        where c.ShopId == Sid && c.Status == 0
                        select new ShoppingCartGoodsModel
                        {
                            Id = c.Id,
                            ShopId = c.ShopId,
                            GoodsId = c.GoodsId,
                            Num = c.Num,
                            Price = 0,
                            Checked = c.Checked,
                            Status = c.Status,
                            BrandId = g.BrandId,
                            GoodsImg = g.GoodsImg,
                            GoodsName = g.GoodsName,
                            GoodsSepc = g.GoodsSepc,
                            GoodsUnit = g.GoodsUnit,
                            GoodsCode = g.GoodsCode
                        };

            if (cartIds != null)
            {
                // 获取已选中，要购买的商品
                query = query.Where(c => cartIds.Contains(c.Id) && c.Checked);
            }
            var list = await query.ToListAsync();
            return list;
        }
    }
}