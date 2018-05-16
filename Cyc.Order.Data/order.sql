/*
Navicat MySQL Data Transfer

Source Server         : 120.79.73.36
Source Server Version : 50722
Source Host           : 120.79.73.36:3306
Source Database       : order

Target Server Type    : MYSQL
Target Server Version : 50722
File Encoding         : 65001

Date: 2018-05-16 09:10:18
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `order_cart`
-- ----------------------------
DROP TABLE IF EXISTS `order_cart`;
CREATE TABLE `order_cart` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `shop_id` int(11) DEFAULT NULL COMMENT '便利店编号',
  `goods_id` int(11) DEFAULT NULL COMMENT '商品编号',
  `num` int(11) DEFAULT NULL COMMENT '商品数量',
  `checked` tinyint(4) DEFAULT '1',
  `status` int(11) DEFAULT NULL COMMENT '购物车状态 1 默认 2 已提交',
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=89 DEFAULT CHARSET=utf8 COMMENT='购物车';

-- ----------------------------
-- Records of order_cart
-- ----------------------------
INSERT INTO `order_cart` VALUES ('17', '1', '1', '7', '0', '2', '2018-04-16 22:36:44', '2018-04-16 22:47:41');
INSERT INTO `order_cart` VALUES ('18', '1', '2', '4', '0', '2', '2018-04-16 22:36:46', '2018-04-16 22:47:41');
INSERT INTO `order_cart` VALUES ('19', '1', '1', '4', '0', '1', '2018-04-16 22:49:27', '2018-04-16 22:49:44');
INSERT INTO `order_cart` VALUES ('20', '1', '2', '4', '0', '2', '2018-04-16 22:49:28', '2018-04-16 23:04:23');
INSERT INTO `order_cart` VALUES ('21', '1', '1', '2', '0', '2', '2018-04-16 22:58:18', '2018-04-16 23:04:22');
INSERT INTO `order_cart` VALUES ('22', '1', '1', '1', '0', '1', '2018-04-16 23:27:11', '2018-04-16 23:27:17');
INSERT INTO `order_cart` VALUES ('23', '1', '2', '2', '0', '2', '2018-04-16 23:27:56', '2018-04-16 23:28:01');
INSERT INTO `order_cart` VALUES ('24', '1', '1', '2', '0', '2', '2018-04-16 23:27:57', '2018-04-16 23:28:01');
INSERT INTO `order_cart` VALUES ('25', '1', '1', '1', '0', '2', '2018-04-17 23:17:58', null);
INSERT INTO `order_cart` VALUES ('26', '1', '2', '1', '0', '2', '2018-04-17 23:17:58', null);
INSERT INTO `order_cart` VALUES ('27', '1', '1', '1', '0', '2', '2018-04-17 23:42:07', null);
INSERT INTO `order_cart` VALUES ('28', '1', '2', '1', '0', '2', '2018-04-17 23:42:07', null);
INSERT INTO `order_cart` VALUES ('29', '1', '1', '2', '0', '2', '2018-04-18 22:33:39', '2018-04-18 22:33:57');
INSERT INTO `order_cart` VALUES ('30', '1', '2', '4', '0', '2', '2018-04-18 22:33:41', '2018-04-18 22:33:59');
INSERT INTO `order_cart` VALUES ('31', '1', '3', '2', '0', '2', '2018-04-19 23:34:05', '2018-04-19 23:34:16');
INSERT INTO `order_cart` VALUES ('32', '1', '1', '1', '0', '2', '2018-04-19 23:34:11', null);
INSERT INTO `order_cart` VALUES ('33', '1', '2', '1', '0', '2', '2018-04-19 23:34:11', null);
INSERT INTO `order_cart` VALUES ('34', '1', '1', '3', '0', '2', '2018-04-19 23:58:40', '2018-04-22 13:16:58');
INSERT INTO `order_cart` VALUES ('35', '1', '2', '3', '0', '2', '2018-04-19 23:58:41', '2018-04-22 13:16:59');
INSERT INTO `order_cart` VALUES ('36', '1', '3', '3', '0', '2', '2018-04-19 23:58:41', '2018-04-22 13:17:00');
INSERT INTO `order_cart` VALUES ('37', '1', '4', '3', '0', '2', '2018-04-22 13:16:53', '2018-04-22 13:17:00');
INSERT INTO `order_cart` VALUES ('38', '1', '1', '5', '0', '1', '2018-04-22 13:24:01', '2018-04-25 22:24:20');
INSERT INTO `order_cart` VALUES ('39', '1', '2', '3', '0', '1', '2018-04-22 13:26:09', '2018-04-25 22:24:21');
INSERT INTO `order_cart` VALUES ('40', '1', '3', '10', '0', '1', '2018-04-22 13:26:10', '2018-04-25 22:24:23');
INSERT INTO `order_cart` VALUES ('41', '1', '4', '10', '0', '1', '2018-04-22 13:26:10', '2018-04-25 22:24:24');
INSERT INTO `order_cart` VALUES ('42', '1', '1', '1', '0', '1', '2018-04-25 22:24:35', '2018-04-25 23:08:38');
INSERT INTO `order_cart` VALUES ('43', '1', '2', '1', '0', '1', '2018-04-25 22:24:36', '2018-04-25 23:08:40');
INSERT INTO `order_cart` VALUES ('44', '1', '3', '1', '0', '1', '2018-04-25 22:24:37', '2018-04-25 23:08:42');
INSERT INTO `order_cart` VALUES ('45', '1', '4', '1', '0', '1', '2018-04-25 22:24:38', '2018-04-25 23:08:44');
INSERT INTO `order_cart` VALUES ('46', '1', '1', '2', '0', '1', '2018-04-25 23:09:05', '2018-05-07 10:47:10');
INSERT INTO `order_cart` VALUES ('47', '1', '2', '1', '0', '1', '2018-04-25 23:09:05', '2018-05-07 10:47:10');
INSERT INTO `order_cart` VALUES ('48', '1', '3', '2', '0', '1', '2018-04-25 23:09:06', '2018-05-07 10:47:08');
INSERT INTO `order_cart` VALUES ('49', '1', '4', '2', '0', '1', '2018-04-25 23:09:06', '2018-05-07 10:47:07');
INSERT INTO `order_cart` VALUES ('50', '1', '1', '1', '0', '1', '2018-05-07 10:47:16', '2018-05-08 10:23:36');
INSERT INTO `order_cart` VALUES ('51', '1', '2', '1', '0', '1', '2018-05-07 10:47:17', '2018-05-08 10:23:37');
INSERT INTO `order_cart` VALUES ('52', '1', '3', '2', '0', '1', '2018-05-07 10:47:19', '2018-05-08 10:23:40');
INSERT INTO `order_cart` VALUES ('53', '1', '4', '1', '0', '1', '2018-05-07 10:47:22', '2018-05-08 10:23:39');
INSERT INTO `order_cart` VALUES ('54', '1', '5', '1', '0', '2', '2018-05-07 15:02:36', null);
INSERT INTO `order_cart` VALUES ('55', '1', '6', '1', '0', '2', '2018-05-07 15:02:37', null);
INSERT INTO `order_cart` VALUES ('56', '1', '7', '1', '0', '2', '2018-05-07 15:02:39', null);
INSERT INTO `order_cart` VALUES ('57', '1', '5', '1', '1', '2', '2018-05-07 15:14:58', '2018-05-15 04:59:25');
INSERT INTO `order_cart` VALUES ('58', '1', '6', '1', '1', '2', '2018-05-07 15:15:00', '2018-05-15 04:59:25');
INSERT INTO `order_cart` VALUES ('59', '1', '7', '1', '1', '2', '2018-05-07 15:15:03', '2018-05-15 04:59:25');
INSERT INTO `order_cart` VALUES ('60', '1', '3', '1', '1', '2', '2018-05-09 17:13:27', '2018-05-15 04:59:25');
INSERT INTO `order_cart` VALUES ('61', '1', '4', '1', '1', '2', '2018-05-09 17:13:29', '2018-05-15 04:59:25');
INSERT INTO `order_cart` VALUES ('69', '2', '1', '1', '1', '2', '2018-05-09 22:18:36', null);
INSERT INTO `order_cart` VALUES ('70', '2', '2', '1', '1', '2', '2018-05-09 22:18:37', null);
INSERT INTO `order_cart` VALUES ('71', '2', '3', '1', '1', '2', '2018-05-09 22:18:38', null);
INSERT INTO `order_cart` VALUES ('72', '2', '4', '1', '1', '2', '2018-05-09 22:18:39', null);
INSERT INTO `order_cart` VALUES ('73', '2', '5', '1', '1', '2', '2018-05-09 22:18:41', null);
INSERT INTO `order_cart` VALUES ('74', '2', '6', '1', '1', '2', '2018-05-09 22:18:44', null);
INSERT INTO `order_cart` VALUES ('75', '2', '7', '1', '1', '2', '2018-05-09 22:18:45', null);
INSERT INTO `order_cart` VALUES ('76', '1', '1', '1', '1', '1', '2018-05-15 05:03:55', '2018-05-15 08:11:42');
INSERT INTO `order_cart` VALUES ('77', '1', '2', '1', '1', '1', '2018-05-15 05:03:57', '2018-05-15 08:11:41');
INSERT INTO `order_cart` VALUES ('78', '1', '3', '1', '1', '1', '2018-05-15 05:03:58', '2018-05-15 05:04:12');
INSERT INTO `order_cart` VALUES ('79', '1', '5', '1', '1', '1', '2018-05-15 05:04:00', '2018-05-15 08:11:40');
INSERT INTO `order_cart` VALUES ('80', '1', '6', '1', '1', '1', '2018-05-15 05:04:02', '2018-05-15 08:11:39');
INSERT INTO `order_cart` VALUES ('81', '1', '7', '1', '1', '1', '2018-05-15 05:04:05', '2018-05-15 08:11:38');
INSERT INTO `order_cart` VALUES ('82', '1', '7', '1', '1', '0', '2018-05-15 10:21:11', null);
INSERT INTO `order_cart` VALUES ('83', '1', '6', '1', '1', '0', '2018-05-15 10:21:12', null);
INSERT INTO `order_cart` VALUES ('84', '1', '5', '1', '1', '0', '2018-05-15 10:21:14', null);
INSERT INTO `order_cart` VALUES ('85', '1', '4', '1', '1', '1', '2018-05-15 10:21:16', '2018-05-15 10:21:26');
INSERT INTO `order_cart` VALUES ('86', '1', '3', '1', '1', '1', '2018-05-15 10:21:17', '2018-05-15 10:21:25');
INSERT INTO `order_cart` VALUES ('87', '1', '2', '1', '1', '0', '2018-05-15 10:21:19', '2018-05-15 10:21:37');
INSERT INTO `order_cart` VALUES ('88', '1', '1', '1', '1', '0', '2018-05-15 10:21:34', null);

-- ----------------------------
-- Table structure for `order_goods`
-- ----------------------------
DROP TABLE IF EXISTS `order_goods`;
CREATE TABLE `order_goods` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `brand_id` int(11) DEFAULT NULL,
  `goods_img` varchar(200) DEFAULT NULL,
  `goods_code` varchar(20) DEFAULT NULL,
  `goods_name` varchar(200) DEFAULT NULL,
  `goods_spec` varchar(45) DEFAULT NULL,
  `goods_unit` varchar(45) DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT '商品状态',
  `add_time` datetime DEFAULT NULL,
  `last_update_time` datetime DEFAULT NULL,
  `is_delete` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='商品表';

-- ----------------------------
-- Records of order_goods
-- ----------------------------
INSERT INTO `order_goods` VALUES ('1', '4', 'http://120.79.73.36/images/636581121022115086.jpg', '6934652192754', '奶牛梦工厂原味', '150g', '杯', '0', '2018-03-31 17:10:10', '2018-05-12 12:43:58', '0');
INSERT INTO `order_goods` VALUES ('2', '2', 'http://120.79.73.36/images/636581121969365193.jpg', '323232323', '安慕希', '12盒/箱', '盒', '1', '2018-03-31 00:00:00', null, '0');
INSERT INTO `order_goods` VALUES ('3', '1', 'http://120.79.73.36/images/636597775665914067.png', '55555555555', '优益C', '350ml', '瓶', '1', '2018-04-19 23:33:34', null, '0');
INSERT INTO `order_goods` VALUES ('4', '2', 'http://120.79.73.36/images/636599997618246337.png', '77758854545', '低温酸奶', '300ml', '瓶', '1', '2018-04-22 13:16:40', null, '0');
INSERT INTO `order_goods` VALUES ('5', '4', 'http://120.79.73.36/images/636613019053286101.jpg', '33333333', '浓缩酸牛奶 原味', '180g', '袋', '0', '2018-05-07 14:58:55', '2018-05-07 14:59:22', '0');
INSERT INTO `order_goods` VALUES ('6', '4', 'http://120.79.73.36/images/636613020365630065.jpg', '32323', '天润浓缩酸奶 冰淇淋化了 ', '180g', '袋', '1', '2018-05-07 15:01:23', null, '0');
INSERT INTO `order_goods` VALUES ('7', '4', 'http://120.79.73.36/images/636613021101921459.jpg', '15542987488', '天润浓缩酸奶 巧克力碎了', '180g', '袋', '1', '2018-05-07 15:02:27', null, '0');

-- ----------------------------
-- Table structure for `order_goods_brand`
-- ----------------------------
DROP TABLE IF EXISTS `order_goods_brand`;
CREATE TABLE `order_goods_brand` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='商品品牌';

-- ----------------------------
-- Records of order_goods_brand
-- ----------------------------
INSERT INTO `order_goods_brand` VALUES ('1', '蒙牛');
INSERT INTO `order_goods_brand` VALUES ('2', '伊利');
INSERT INTO `order_goods_brand` VALUES ('3', '奶牛梦工厂');
INSERT INTO `order_goods_brand` VALUES ('4', '天润牛奶');

-- ----------------------------
-- Table structure for `order_goods_price`
-- ----------------------------
DROP TABLE IF EXISTS `order_goods_price`;
CREATE TABLE `order_goods_price` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `goods_id` int(11) DEFAULT NULL COMMENT '商品ID',
  `goods_price` decimal(18,2) DEFAULT NULL COMMENT '商品价格',
  `shop_id` int(11) DEFAULT NULL COMMENT '店铺ID，如果为NULL表示该价格适用所有店铺',
  `is_delete` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8 COMMENT='商品价格表';

-- ----------------------------
-- Records of order_goods_price
-- ----------------------------
INSERT INTO `order_goods_price` VALUES ('1', '1', '4.20', '0', '0');
INSERT INTO `order_goods_price` VALUES ('2', '2', '49.00', '0', '0');
INSERT INTO `order_goods_price` VALUES ('3', '1', '6.50', '1', '0');
INSERT INTO `order_goods_price` VALUES ('4', '2', '48.50', '1', '0');
INSERT INTO `order_goods_price` VALUES ('5', '3', '7.00', '0', '0');
INSERT INTO `order_goods_price` VALUES ('6', '4', '3.50', '0', '0');
INSERT INTO `order_goods_price` VALUES ('7', '5', '5.50', '0', '0');
INSERT INTO `order_goods_price` VALUES ('8', '6', '5.50', '0', '0');
INSERT INTO `order_goods_price` VALUES ('9', '7', '5.50', '0', '0');
INSERT INTO `order_goods_price` VALUES ('25', '5', '11.00', '1', '0');

-- ----------------------------
-- Table structure for `order_goods_spec`
-- ----------------------------
DROP TABLE IF EXISTS `order_goods_spec`;
CREATE TABLE `order_goods_spec` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of order_goods_spec
-- ----------------------------

-- ----------------------------
-- Table structure for `order_record`
-- ----------------------------
DROP TABLE IF EXISTS `order_record`;
CREATE TABLE `order_record` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `shop_id` int(11) DEFAULT NULL COMMENT '店铺ID',
  `pay_price` decimal(18,2) DEFAULT NULL COMMENT '实际支付价格',
  `is_pay` tinyint(4) DEFAULT NULL COMMENT '是否已支付 0未支付 1已支付',
  `pay_time` datetime DEFAULT NULL COMMENT '支付时间',
  `num` int(11) DEFAULT NULL COMMENT '商品数量',
  `total_amount` decimal(18,2) DEFAULT NULL COMMENT '总额',
  `status` int(11) DEFAULT NULL COMMENT '订单状态 ',
  `order_date` datetime DEFAULT NULL COMMENT '订单日期',
  `end_date` datetime DEFAULT NULL COMMENT '订单结束日期',
  `region_id` int(11) DEFAULT NULL COMMENT '订单所属区域编号',
  `consignee` varchar(45) DEFAULT NULL,
  `mobile_phone` varchar(45) DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1000071 DEFAULT CHARSET=utf8 COMMENT='订单记录表';

-- ----------------------------
-- Records of order_record
-- ----------------------------
INSERT INTO `order_record` VALUES ('1000039', '1', '917.00', null, null, '8', '917.00', '0', '2018-04-16 22:36:56', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-04-16 22:36:59');
INSERT INTO `order_record` VALUES ('1000040', '1', '417.00', null, null, '3', '417.00', '0', '2018-04-16 22:58:25', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000041', '1', '517.00', null, null, '4', '517.00', '1', '2018-04-16 22:58:32', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000042', '1', '517.00', null, null, '4', '517.00', '1', '2018-04-16 23:00:31', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000043', '1', '756.00', null, null, '6', '756.00', '10', '2018-04-16 23:04:28', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000044', '1', '756.00', null, null, '6', '756.00', '1', '2018-04-16 23:07:03', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-04-16 23:07:04');
INSERT INTO `order_record` VALUES ('1000045', '1', '478.00', null, null, '4', '478.00', '1', '2018-04-16 23:28:04', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000046', '1', '478.00', null, null, '4', '478.00', '99', '2018-04-16 23:28:22', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000047', '1', '478.00', null, null, '4', '478.00', '10', '2018-04-16 23:28:37', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-04-16 23:28:40');
INSERT INTO `order_record` VALUES ('1000048', '1', '239.00', null, null, '2', '239.00', '99', '2018-04-17 23:18:05', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-04-17 23:18:08');
INSERT INTO `order_record` VALUES ('1000049', '1', '239.00', null, null, '2', '239.00', '10', '2018-04-17 23:42:09', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-04-17 23:42:11');
INSERT INTO `order_record` VALUES ('1000050', '1', '756.00', null, null, '6', '756.00', '10', '2018-04-18 23:36:02', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-04-18 23:36:05');
INSERT INTO `order_record` VALUES ('1000051', '1', '255.00', null, null, '4', '255.00', '10', '2018-04-19 23:55:24', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000052', '1', '255.00', null, null, '4', '255.00', '99', '2018-04-19 23:55:29', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-04-19 23:55:36');
INSERT INTO `order_record` VALUES ('1000053', '1', '754.50', null, null, '12', '754.50', '10', '2018-04-22 13:17:02', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-04-22 13:17:10');
INSERT INTO `order_record` VALUES ('1000054', '1', '1277.00', null, null, '21', '1277.00', '10', '2018-04-22 13:28:46', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000055', '1', '1277.00', null, null, '21', '1277.00', '10', '2018-04-22 13:36:56', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000056', '1', '314.50', null, null, '16', '314.50', '10', '2018-04-22 13:40:36', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000057', '1', '251.50', null, null, '4', '251.50', '99', '2018-04-25 23:22:58', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000058', '1', '353.50', null, null, '5', '353.50', '99', '2018-04-25 23:27:54', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000061', '1', '14.00', null, null, '2', '14.00', '0', '2018-05-07 12:35:21', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000062', '1', '204.50', null, null, '5', '204.50', '0', '2018-05-07 12:35:27', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000063', '1', '204.50', null, null, '5', '204.50', '0', '2018-05-07 12:47:45', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000064', '1', '16.50', null, null, '3', '16.50', '0', '2018-05-07 15:02:53', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000065', '1', '16.50', null, null, '3', '16.50', '0', '2018-05-07 15:09:03', null, null, null, null, null, null);
INSERT INTO `order_record` VALUES ('1000066', '1', '16.50', null, null, '3', '16.50', '10', '2018-05-07 15:13:04', null, null, '京东便利店', '1853302022', '杨家坪西郊路-北大资源燕南5街区', '2018-05-07 15:13:14');
INSERT INTO `order_record` VALUES ('1000068', '2', '268.00', null, null, '7', '268.00', '10', '2018-05-09 22:19:00', null, null, '711高科总部店1', '18910012018', '北部新区黄山大道64号', '2018-05-09 22:19:21');
INSERT INTO `order_record` VALUES ('1000069', '1', '32.50', null, null, '5', '32.50', '99', '2018-05-15 04:59:23', null, null, '京东便利店', '18580760058', '杨家坪西郊路-北大资源燕南5街区', '2018-05-15 04:59:25');
INSERT INTO `order_record` VALUES ('1000070', '1', '77.00', null, null, '5', '77.00', '0', '2018-05-15 05:04:18', null, null, null, null, null, null);

-- ----------------------------
-- Table structure for `order_record_detail`
-- ----------------------------
DROP TABLE IF EXISTS `order_record_detail`;
CREATE TABLE `order_record_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) DEFAULT NULL,
  `goods_id` int(11) DEFAULT NULL,
  `goods_code` varchar(20) DEFAULT NULL,
  `goods_name` varchar(200) DEFAULT NULL,
  `goods_img` varchar(200) DEFAULT NULL,
  `goods_price` decimal(18,2) DEFAULT NULL,
  `goods_num` int(11) DEFAULT NULL,
  `add_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=169 DEFAULT CHARSET=utf8 COMMENT='订单记录详情表';

-- ----------------------------
-- Records of order_record_detail
-- ----------------------------
INSERT INTO `order_record_detail` VALUES ('74', '1000039', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '5', '2018-04-16 22:36:56');
INSERT INTO `order_record_detail` VALUES ('75', '1000039', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '3', '2018-04-16 22:36:56');
INSERT INTO `order_record_detail` VALUES ('76', '1000040', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '3', '2018-04-16 22:58:25');
INSERT INTO `order_record_detail` VALUES ('77', '1000041', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '3', '2018-04-16 22:58:32');
INSERT INTO `order_record_detail` VALUES ('78', '1000041', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '1', '2018-04-16 22:58:32');
INSERT INTO `order_record_detail` VALUES ('79', '1000042', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '3', '2018-04-16 23:00:31');
INSERT INTO `order_record_detail` VALUES ('80', '1000042', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '1', '2018-04-16 23:00:31');
INSERT INTO `order_record_detail` VALUES ('81', '1000043', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '4', '2018-04-16 23:04:28');
INSERT INTO `order_record_detail` VALUES ('82', '1000043', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '2', '2018-04-16 23:04:28');
INSERT INTO `order_record_detail` VALUES ('83', '1000044', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '4', '2018-04-16 23:07:03');
INSERT INTO `order_record_detail` VALUES ('84', '1000044', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '2', '2018-04-16 23:07:03');
INSERT INTO `order_record_detail` VALUES ('85', '1000045', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '2', '2018-04-16 23:28:04');
INSERT INTO `order_record_detail` VALUES ('86', '1000045', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '2', '2018-04-16 23:28:04');
INSERT INTO `order_record_detail` VALUES ('87', '1000046', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '2', '2018-04-16 23:28:22');
INSERT INTO `order_record_detail` VALUES ('88', '1000046', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '2', '2018-04-16 23:28:22');
INSERT INTO `order_record_detail` VALUES ('89', '1000047', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '2', '2018-04-16 23:28:37');
INSERT INTO `order_record_detail` VALUES ('90', '1000047', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '2', '2018-04-16 23:28:37');
INSERT INTO `order_record_detail` VALUES ('91', '1000048', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '1', '2018-04-17 23:18:05');
INSERT INTO `order_record_detail` VALUES ('92', '1000048', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-04-17 23:18:05');
INSERT INTO `order_record_detail` VALUES ('93', '1000049', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '1', '2018-04-17 23:42:09');
INSERT INTO `order_record_detail` VALUES ('94', '1000049', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-04-17 23:42:09');
INSERT INTO `order_record_detail` VALUES ('95', '1000050', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '100.00', '2', '2018-04-18 23:36:02');
INSERT INTO `order_record_detail` VALUES ('96', '1000050', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '4', '2018-04-18 23:36:02');
INSERT INTO `order_record_detail` VALUES ('97', '1000051', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '2', '2018-04-19 23:55:24');
INSERT INTO `order_record_detail` VALUES ('98', '1000051', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '1', '2018-04-19 23:55:24');
INSERT INTO `order_record_detail` VALUES ('99', '1000051', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-04-19 23:55:24');
INSERT INTO `order_record_detail` VALUES ('100', '1000052', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '2', '2018-04-19 23:55:29');
INSERT INTO `order_record_detail` VALUES ('101', '1000052', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '1', '2018-04-19 23:55:29');
INSERT INTO `order_record_detail` VALUES ('102', '1000052', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-04-19 23:55:29');
INSERT INTO `order_record_detail` VALUES ('103', '1000053', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '3', '2018-04-22 13:17:02');
INSERT INTO `order_record_detail` VALUES ('104', '1000053', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '3', '2018-04-22 13:17:02');
INSERT INTO `order_record_detail` VALUES ('105', '1000053', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '3', '2018-04-22 13:17:02');
INSERT INTO `order_record_detail` VALUES ('106', '1000053', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '3', '2018-04-22 13:17:02');
INSERT INTO `order_record_detail` VALUES ('107', '1000054', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '1', '2018-04-22 13:28:46');
INSERT INTO `order_record_detail` VALUES ('108', '1000054', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '8', '2018-04-22 13:28:46');
INSERT INTO `order_record_detail` VALUES ('109', '1000054', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '6', '2018-04-22 13:28:46');
INSERT INTO `order_record_detail` VALUES ('110', '1000054', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '6', '2018-04-22 13:28:46');
INSERT INTO `order_record_detail` VALUES ('111', '1000055', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '1', '2018-04-22 13:36:56');
INSERT INTO `order_record_detail` VALUES ('112', '1000055', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '8', '2018-04-22 13:36:56');
INSERT INTO `order_record_detail` VALUES ('113', '1000055', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '6', '2018-04-22 13:36:56');
INSERT INTO `order_record_detail` VALUES ('114', '1000055', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '6', '2018-04-22 13:36:56');
INSERT INTO `order_record_detail` VALUES ('115', '1000056', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '1', '2018-04-22 13:40:36');
INSERT INTO `order_record_detail` VALUES ('116', '1000056', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-04-22 13:40:36');
INSERT INTO `order_record_detail` VALUES ('117', '1000056', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '7', '2018-04-22 13:40:36');
INSERT INTO `order_record_detail` VALUES ('118', '1000056', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '7', '2018-04-22 13:40:36');
INSERT INTO `order_record_detail` VALUES ('119', '1000057', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '1', '2018-04-25 23:22:58');
INSERT INTO `order_record_detail` VALUES ('120', '1000057', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-04-25 23:22:58');
INSERT INTO `order_record_detail` VALUES ('121', '1000057', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '1', '2018-04-25 23:22:58');
INSERT INTO `order_record_detail` VALUES ('122', '1000057', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '1', '2018-04-25 23:22:58');
INSERT INTO `order_record_detail` VALUES ('123', '1000058', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '2', '2018-04-25 23:27:54');
INSERT INTO `order_record_detail` VALUES ('124', '1000058', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-04-25 23:27:54');
INSERT INTO `order_record_detail` VALUES ('125', '1000058', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '1', '2018-04-25 23:27:54');
INSERT INTO `order_record_detail` VALUES ('126', '1000058', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '1', '2018-04-25 23:27:54');
INSERT INTO `order_record_detail` VALUES ('127', '1000061', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '2', '2018-05-07 12:35:21');
INSERT INTO `order_record_detail` VALUES ('128', '1000062', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '88.00', '1', '2018-05-07 12:35:27');
INSERT INTO `order_record_detail` VALUES ('129', '1000062', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '99.00', '1', '2018-05-07 12:35:27');
INSERT INTO `order_record_detail` VALUES ('130', '1000062', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '2', '2018-05-07 12:35:27');
INSERT INTO `order_record_detail` VALUES ('131', '1000062', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '1', '2018-05-07 12:35:27');
INSERT INTO `order_record_detail` VALUES ('132', '1000063', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '88.00', '1', '2018-05-07 12:47:45');
INSERT INTO `order_record_detail` VALUES ('133', '1000063', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '99.00', '1', '2018-05-07 12:47:45');
INSERT INTO `order_record_detail` VALUES ('134', '1000063', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '2', '2018-05-07 12:47:45');
INSERT INTO `order_record_detail` VALUES ('135', '1000063', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '1', '2018-05-07 12:47:45');
INSERT INTO `order_record_detail` VALUES ('136', '1000064', '5', '33333333', '浓缩酸牛奶 原味', 'http://120.79.73.36/images/636613019053286101.jpg', '5.50', '1', '2018-05-07 15:02:53');
INSERT INTO `order_record_detail` VALUES ('137', '1000064', '6', '32323', '天润浓缩酸奶 冰淇淋化了 ', 'http://120.79.73.36/images/636613020365630065.jpg', '5.50', '1', '2018-05-07 15:02:53');
INSERT INTO `order_record_detail` VALUES ('138', '1000064', '7', '15542987488', '天润浓缩酸奶 巧克力碎了', 'http://120.79.73.36/images/636613021101921459.jpg', '5.50', '1', '2018-05-07 15:02:53');
INSERT INTO `order_record_detail` VALUES ('139', '1000065', '5', '33333333', '浓缩酸牛奶 原味', 'http://120.79.73.36/images/636613019053286101.jpg', '5.50', '1', '2018-05-07 15:09:03');
INSERT INTO `order_record_detail` VALUES ('140', '1000065', '6', '32323', '天润浓缩酸奶 冰淇淋化了 ', 'http://120.79.73.36/images/636613020365630065.jpg', '5.50', '1', '2018-05-07 15:09:03');
INSERT INTO `order_record_detail` VALUES ('141', '1000065', '7', '15542987488', '天润浓缩酸奶 巧克力碎了', 'http://120.79.73.36/images/636613021101921459.jpg', '5.50', '1', '2018-05-07 15:09:03');
INSERT INTO `order_record_detail` VALUES ('142', '1000066', '5', '33333333', '浓缩酸牛奶 原味', 'http://120.79.73.36/images/636613019053286101.jpg', '5.50', '1', '2018-05-07 15:13:04');
INSERT INTO `order_record_detail` VALUES ('143', '1000066', '6', '32323', '天润浓缩酸奶 冰淇淋化了 ', 'http://120.79.73.36/images/636613020365630065.jpg', '5.50', '1', '2018-05-07 15:13:04');
INSERT INTO `order_record_detail` VALUES ('144', '1000066', '7', '15542987488', '天润浓缩酸奶 巧克力碎了', 'http://120.79.73.36/images/636613021101921459.jpg', '5.50', '1', '2018-05-07 15:13:04');
INSERT INTO `order_record_detail` VALUES ('145', '1000067', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '1', '2018-05-09 22:04:05');
INSERT INTO `order_record_detail` VALUES ('146', '1000067', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-05-09 22:04:05');
INSERT INTO `order_record_detail` VALUES ('147', '1000067', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '1', '2018-05-09 22:04:05');
INSERT INTO `order_record_detail` VALUES ('148', '1000067', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '1', '2018-05-09 22:04:05');
INSERT INTO `order_record_detail` VALUES ('149', '1000067', '5', '33333333', '浓缩酸牛奶 原味', 'http://120.79.73.36/images/636613019053286101.jpg', '5.50', '1', '2018-05-09 22:04:05');
INSERT INTO `order_record_detail` VALUES ('150', '1000067', '6', '32323', '天润浓缩酸奶 冰淇淋化了 ', 'http://120.79.73.36/images/636613020365630065.jpg', '5.50', '1', '2018-05-09 22:04:05');
INSERT INTO `order_record_detail` VALUES ('151', '1000067', '7', '15542987488', '天润浓缩酸奶 巧克力碎了', 'http://120.79.73.36/images/636613021101921459.jpg', '5.50', '1', '2018-05-09 22:04:05');
INSERT INTO `order_record_detail` VALUES ('152', '1000068', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '102.00', '1', '2018-05-09 22:19:00');
INSERT INTO `order_record_detail` VALUES ('153', '1000068', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '139.00', '1', '2018-05-09 22:19:00');
INSERT INTO `order_record_detail` VALUES ('154', '1000068', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '1', '2018-05-09 22:19:00');
INSERT INTO `order_record_detail` VALUES ('155', '1000068', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '1', '2018-05-09 22:19:00');
INSERT INTO `order_record_detail` VALUES ('156', '1000068', '5', '33333333', '浓缩酸牛奶 原味', 'http://120.79.73.36/images/636613019053286101.jpg', '5.50', '1', '2018-05-09 22:19:00');
INSERT INTO `order_record_detail` VALUES ('157', '1000068', '6', '32323', '天润浓缩酸奶 冰淇淋化了 ', 'http://120.79.73.36/images/636613020365630065.jpg', '5.50', '1', '2018-05-09 22:19:00');
INSERT INTO `order_record_detail` VALUES ('158', '1000068', '7', '15542987488', '天润浓缩酸奶 巧克力碎了', 'http://120.79.73.36/images/636613021101921459.jpg', '5.50', '1', '2018-05-09 22:19:00');
INSERT INTO `order_record_detail` VALUES ('159', '1000069', '5', '33333333', '浓缩酸牛奶 原味', 'http://120.79.73.36/images/636613019053286101.jpg', '11.00', '1', '2018-05-15 04:59:23');
INSERT INTO `order_record_detail` VALUES ('160', '1000069', '6', '32323', '天润浓缩酸奶 冰淇淋化了 ', 'http://120.79.73.36/images/636613020365630065.jpg', '5.50', '1', '2018-05-15 04:59:23');
INSERT INTO `order_record_detail` VALUES ('161', '1000069', '7', '15542987488', '天润浓缩酸奶 巧克力碎了', 'http://120.79.73.36/images/636613021101921459.jpg', '5.50', '1', '2018-05-15 04:59:23');
INSERT INTO `order_record_detail` VALUES ('162', '1000069', '3', '55555555555', '优益C', 'http://120.79.73.36/images/636597775665914067.png', '7.00', '1', '2018-05-15 04:59:23');
INSERT INTO `order_record_detail` VALUES ('163', '1000069', '4', '77758854545', '低温酸奶', 'http://120.79.73.36/images/636599997618246337.png', '3.50', '1', '2018-05-15 04:59:23');
INSERT INTO `order_record_detail` VALUES ('164', '1000070', '1', '6934652192754', '奶牛梦工厂原味', 'http://120.79.73.36/images/636581121022115086.jpg', '6.50', '1', '2018-05-15 05:04:18');
INSERT INTO `order_record_detail` VALUES ('165', '1000070', '2', '323232323', '安慕希', 'http://120.79.73.36/images/636581121969365193.jpg', '48.50', '1', '2018-05-15 05:04:18');
INSERT INTO `order_record_detail` VALUES ('166', '1000070', '5', '33333333', '浓缩酸牛奶 原味', 'http://120.79.73.36/images/636613019053286101.jpg', '11.00', '1', '2018-05-15 05:04:18');
INSERT INTO `order_record_detail` VALUES ('167', '1000070', '6', '32323', '天润浓缩酸奶 冰淇淋化了 ', 'http://120.79.73.36/images/636613020365630065.jpg', '5.50', '1', '2018-05-15 05:04:18');
INSERT INTO `order_record_detail` VALUES ('168', '1000070', '7', '15542987488', '天润浓缩酸奶 巧克力碎了', 'http://120.79.73.36/images/636613021101921459.jpg', '5.50', '1', '2018-05-15 05:04:18');

-- ----------------------------
-- Table structure for `order_region`
-- ----------------------------
DROP TABLE IF EXISTS `order_region`;
CREATE TABLE `order_region` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='区域';

-- ----------------------------
-- Records of order_region
-- ----------------------------
INSERT INTO `order_region` VALUES ('1', '九龙坡区');
INSERT INTO `order_region` VALUES ('2', '南岸区');
INSERT INTO `order_region` VALUES ('3', '渝中区');
INSERT INTO `order_region` VALUES ('4', '江北区');
INSERT INTO `order_region` VALUES ('5', '巴南区');
INSERT INTO `order_region` VALUES ('6', '大渡口');
INSERT INTO `order_region` VALUES ('7', '沙坪坝');

-- ----------------------------
-- Table structure for `order_shop`
-- ----------------------------
DROP TABLE IF EXISTS `order_shop`;
CREATE TABLE `order_shop` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL COMMENT '便利店名称',
  `phone` varchar(20) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `linkman` varchar(20) DEFAULT NULL COMMENT '联系人',
  `address` varchar(100) DEFAULT NULL COMMENT '便利店地址',
  `region_id` int(11) DEFAULT NULL COMMENT '区域ID',
  `user_type` tinyint(4) NOT NULL DEFAULT '0' COMMENT '用户类型 0 用户，1 商家',
  `add_date` datetime DEFAULT NULL,
  `is_delete` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='便利店';

-- ----------------------------
-- Records of order_shop
-- ----------------------------
INSERT INTO `order_shop` VALUES ('1', '京东便利店', '18580760058', 'ISGMyneATSuhkiwz4BURBQ==', 'Mainly electronic', '杨家坪西郊路-北大资源燕南5街区', '3', '1', '2018-04-19 23:03:56', '0');
INSERT INTO `order_shop` VALUES ('2', '711高科总部店1', '13212319938', 'ISGMyneATSuhkiwz4BURBQ==', '张山', '北部新区黄山大道64号', '4', '0', '2018-04-19 23:05:00', '0');
INSERT INTO `order_shop` VALUES ('3', '罗森大坪英利国际店', '13121212120', 'ISGMyneATSuhkiwz4BURBQ==', '二狗', '渝中区石油路', '3', '0', '2018-04-19 23:57:55', '0');
