-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: order
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `order_cart`
--

DROP TABLE IF EXISTS `order_cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8 COMMENT='购物车';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_cart`
--

LOCK TABLES `order_cart` WRITE;
/*!40000 ALTER TABLE `order_cart` DISABLE KEYS */;
INSERT INTO `order_cart` VALUES (17,1,1,7,0,2,'2018-04-16 22:36:44','2018-04-16 22:47:41'),(18,1,2,4,0,2,'2018-04-16 22:36:46','2018-04-16 22:47:41'),(19,1,1,4,0,1,'2018-04-16 22:49:27','2018-04-16 22:49:44'),(20,1,2,4,0,2,'2018-04-16 22:49:28','2018-04-16 23:04:23'),(21,1,1,2,0,2,'2018-04-16 22:58:18','2018-04-16 23:04:22'),(22,1,1,1,0,1,'2018-04-16 23:27:11','2018-04-16 23:27:17'),(23,1,2,2,0,2,'2018-04-16 23:27:56','2018-04-16 23:28:01'),(24,1,1,2,0,2,'2018-04-16 23:27:57','2018-04-16 23:28:01'),(25,1,1,1,0,2,'2018-04-17 23:17:58',NULL),(26,1,2,1,0,2,'2018-04-17 23:17:58',NULL),(27,1,1,1,0,2,'2018-04-17 23:42:07',NULL),(28,1,2,1,0,2,'2018-04-17 23:42:07',NULL),(29,1,1,2,0,2,'2018-04-18 22:33:39','2018-04-18 22:33:57'),(30,1,2,4,0,2,'2018-04-18 22:33:41','2018-04-18 22:33:59'),(31,1,3,2,0,2,'2018-04-19 23:34:05','2018-04-19 23:34:16'),(32,1,1,1,0,2,'2018-04-19 23:34:11',NULL),(33,1,2,1,0,2,'2018-04-19 23:34:11',NULL),(34,1,1,3,0,2,'2018-04-19 23:58:40','2018-04-22 13:16:58'),(35,1,2,3,0,2,'2018-04-19 23:58:41','2018-04-22 13:16:59'),(36,1,3,3,0,2,'2018-04-19 23:58:41','2018-04-22 13:17:00'),(37,1,4,3,0,2,'2018-04-22 13:16:53','2018-04-22 13:17:00'),(38,1,1,5,0,1,'2018-04-22 13:24:01','2018-04-25 22:24:20'),(39,1,2,3,0,1,'2018-04-22 13:26:09','2018-04-25 22:24:21'),(40,1,3,10,0,1,'2018-04-22 13:26:10','2018-04-25 22:24:23'),(41,1,4,10,0,1,'2018-04-22 13:26:10','2018-04-25 22:24:24'),(42,1,1,1,1,1,'2018-04-25 22:24:35','2018-04-25 23:08:38'),(43,1,2,1,1,1,'2018-04-25 22:24:36','2018-04-25 23:08:40'),(44,1,3,1,1,1,'2018-04-25 22:24:37','2018-04-25 23:08:42'),(45,1,4,1,1,1,'2018-04-25 22:24:38','2018-04-25 23:08:44'),(46,1,1,6,1,0,'2018-04-25 23:09:05','2018-04-25 23:29:44'),(47,1,2,1,1,0,'2018-04-25 23:09:05',NULL),(48,1,3,1,1,0,'2018-04-25 23:09:06',NULL),(49,1,4,1,1,0,'2018-04-25 23:09:06',NULL);
/*!40000 ALTER TABLE `order_cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_goods`
--

DROP TABLE IF EXISTS `order_goods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  `is_delete` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='商品表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_goods`
--

LOCK TABLES `order_goods` WRITE;
/*!40000 ALTER TABLE `order_goods` DISABLE KEYS */;
INSERT INTO `order_goods` VALUES (1,4,'http://localhost:55178/images/636581121022115086.jpg','6934652192754','奶牛梦工厂原味','150g','杯',0,'2018-03-31 17:10:10','2018-04-19 23:50:49',0),(2,2,'http://localhost:55178/images/636581121969365193.jpg','323232323','安慕希','12盒/箱','盒',1,'2018-03-31 00:00:00',NULL,0),(3,1,'http://localhost:55178/images/636597775665914067.png','55555555555','优益C','350ml','瓶',1,'2018-04-19 23:33:34',NULL,0),(4,2,'http://localhost:55178/images/636599997618246337.png','77758854545','低温酸奶','300ml','瓶',1,'2018-04-22 13:16:40',NULL,0);
/*!40000 ALTER TABLE `order_goods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_goods_brand`
--

DROP TABLE IF EXISTS `order_goods_brand`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_goods_brand` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='商品品牌';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_goods_brand`
--

LOCK TABLES `order_goods_brand` WRITE;
/*!40000 ALTER TABLE `order_goods_brand` DISABLE KEYS */;
INSERT INTO `order_goods_brand` VALUES (1,'蒙牛'),(2,'伊利'),(3,'奶牛梦工厂'),(4,'天润牛奶');
/*!40000 ALTER TABLE `order_goods_brand` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_goods_price`
--

DROP TABLE IF EXISTS `order_goods_price`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_goods_price` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `goods_id` int(11) DEFAULT NULL COMMENT '商品ID',
  `goods_price` decimal(10,2) DEFAULT NULL COMMENT '商品价格',
  `shop_id` int(11) DEFAULT NULL COMMENT '店铺ID，如果为NULL表示该价格适用所有店铺',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='商品价格表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_goods_price`
--

LOCK TABLES `order_goods_price` WRITE;
/*!40000 ALTER TABLE `order_goods_price` DISABLE KEYS */;
INSERT INTO `order_goods_price` VALUES (1,1,102.00,0),(2,2,139.00,0),(3,1,88.00,2),(4,2,99.00,2),(5,3,7.00,0),(6,4,3.50,0);
/*!40000 ALTER TABLE `order_goods_price` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_goods_spec`
--

DROP TABLE IF EXISTS `order_goods_spec`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_goods_spec` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_goods_spec`
--

LOCK TABLES `order_goods_spec` WRITE;
/*!40000 ALTER TABLE `order_goods_spec` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_goods_spec` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_record`
--

DROP TABLE IF EXISTS `order_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_record` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `shop_id` int(11) DEFAULT NULL COMMENT '店铺ID',
  `pay_price` decimal(10,2) DEFAULT NULL COMMENT '实际支付价格',
  `is_pay` tinyint(4) DEFAULT NULL COMMENT '是否已支付 0未支付 1已支付',
  `pay_time` datetime DEFAULT NULL COMMENT '支付时间',
  `num` int(11) DEFAULT NULL COMMENT '商品数量',
  `total_amount` decimal(10,2) DEFAULT NULL COMMENT '总额',
  `status` int(11) DEFAULT NULL COMMENT '订单状态 ',
  `order_date` datetime DEFAULT NULL COMMENT '订单日期',
  `end_date` datetime DEFAULT NULL COMMENT '订单结束日期',
  `region_id` int(11) DEFAULT NULL COMMENT '订单所属区域编号',
  `consignee` varchar(45) DEFAULT NULL,
  `mobile_phone` varchar(45) DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1000059 DEFAULT CHARSET=utf8 COMMENT='订单记录表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_record`
--

LOCK TABLES `order_record` WRITE;
/*!40000 ALTER TABLE `order_record` DISABLE KEYS */;
INSERT INTO `order_record` VALUES (1000039,1,917.00,NULL,NULL,8,917.00,1,'2018-04-16 22:36:56',NULL,NULL,'京东便利店','1853302022','杨家坪西郊路-北大资源燕南5街区','2018-04-16 22:36:59'),(1000040,1,417.00,NULL,NULL,3,417.00,0,'2018-04-16 22:58:25',NULL,NULL,NULL,NULL,NULL,NULL),(1000041,1,517.00,NULL,NULL,4,517.00,0,'2018-04-16 22:58:32',NULL,NULL,NULL,NULL,NULL,NULL),(1000042,1,517.00,NULL,NULL,4,517.00,0,'2018-04-16 23:00:31',NULL,NULL,NULL,NULL,NULL,NULL),(1000043,1,756.00,NULL,NULL,6,756.00,0,'2018-04-16 23:04:28',NULL,NULL,NULL,NULL,NULL,NULL),(1000044,1,756.00,NULL,NULL,6,756.00,1,'2018-04-16 23:07:03',NULL,NULL,'京东便利店','1853302022','杨家坪西郊路-北大资源燕南5街区','2018-04-16 23:07:04'),(1000045,1,478.00,NULL,NULL,4,478.00,0,'2018-04-16 23:28:04',NULL,NULL,NULL,NULL,NULL,NULL),(1000046,1,478.00,NULL,NULL,4,478.00,0,'2018-04-16 23:28:22',NULL,NULL,NULL,NULL,NULL,NULL),(1000047,1,478.00,NULL,NULL,4,478.00,1,'2018-04-16 23:28:37',NULL,NULL,'京东便利店','1853302022','杨家坪西郊路-北大资源燕南5街区','2018-04-16 23:28:40'),(1000048,1,239.00,NULL,NULL,2,239.00,1,'2018-04-17 23:18:05',NULL,NULL,'京东便利店','1853302022','杨家坪西郊路-北大资源燕南5街区','2018-04-17 23:18:08'),(1000049,1,239.00,NULL,NULL,2,239.00,1,'2018-04-17 23:42:09',NULL,NULL,'京东便利店','1853302022','杨家坪西郊路-北大资源燕南5街区','2018-04-17 23:42:11'),(1000050,1,756.00,NULL,NULL,6,756.00,1,'2018-04-18 23:36:02',NULL,NULL,'京东便利店','1853302022','杨家坪西郊路-北大资源燕南5街区','2018-04-18 23:36:05'),(1000051,1,255.00,NULL,NULL,4,255.00,0,'2018-04-19 23:55:24',NULL,NULL,NULL,NULL,NULL,NULL),(1000052,1,255.00,NULL,NULL,4,255.00,99,'2018-04-19 23:55:29',NULL,NULL,'京东便利店','1853302022','杨家坪西郊路-北大资源燕南5街区','2018-04-19 23:55:36'),(1000053,1,754.50,NULL,NULL,12,754.50,1,'2018-04-22 13:17:02',NULL,NULL,'京东便利店','1853302022','杨家坪西郊路-北大资源燕南5街区','2018-04-22 13:17:10'),(1000054,1,1277.00,NULL,NULL,21,1277.00,0,'2018-04-22 13:28:46',NULL,NULL,NULL,NULL,NULL,NULL),(1000055,1,1277.00,NULL,NULL,21,1277.00,0,'2018-04-22 13:36:56',NULL,NULL,NULL,NULL,NULL,NULL),(1000056,1,314.50,NULL,NULL,16,314.50,0,'2018-04-22 13:40:36',NULL,NULL,NULL,NULL,NULL,NULL),(1000057,1,251.50,NULL,NULL,4,251.50,0,'2018-04-25 23:22:58',NULL,NULL,NULL,NULL,NULL,NULL),(1000058,1,353.50,NULL,NULL,5,353.50,0,'2018-04-25 23:27:54',NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `order_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_record_detail`
--

DROP TABLE IF EXISTS `order_record_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_record_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) DEFAULT NULL,
  `goods_id` int(11) DEFAULT NULL,
  `goods_code` varchar(20) DEFAULT NULL,
  `goods_name` varchar(200) DEFAULT NULL,
  `goods_img` varchar(200) DEFAULT NULL,
  `goods_price` decimal(10,2) DEFAULT NULL,
  `goods_num` int(11) DEFAULT NULL,
  `add_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=127 DEFAULT CHARSET=utf8 COMMENT='订单记录详情表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_record_detail`
--

LOCK TABLES `order_record_detail` WRITE;
/*!40000 ALTER TABLE `order_record_detail` DISABLE KEYS */;
INSERT INTO `order_record_detail` VALUES (74,1000039,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,5,'2018-04-16 22:36:56'),(75,1000039,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,3,'2018-04-16 22:36:56'),(76,1000040,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,3,'2018-04-16 22:58:25'),(77,1000041,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,3,'2018-04-16 22:58:32'),(78,1000041,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,1,'2018-04-16 22:58:32'),(79,1000042,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,3,'2018-04-16 23:00:31'),(80,1000042,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,1,'2018-04-16 23:00:31'),(81,1000043,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,4,'2018-04-16 23:04:28'),(82,1000043,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,2,'2018-04-16 23:04:28'),(83,1000044,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,4,'2018-04-16 23:07:03'),(84,1000044,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,2,'2018-04-16 23:07:03'),(85,1000045,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,2,'2018-04-16 23:28:04'),(86,1000045,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,2,'2018-04-16 23:28:04'),(87,1000046,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,2,'2018-04-16 23:28:22'),(88,1000046,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,2,'2018-04-16 23:28:22'),(89,1000047,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,2,'2018-04-16 23:28:37'),(90,1000047,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,2,'2018-04-16 23:28:37'),(91,1000048,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,1,'2018-04-17 23:18:05'),(92,1000048,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,1,'2018-04-17 23:18:05'),(93,1000049,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,1,'2018-04-17 23:42:09'),(94,1000049,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,1,'2018-04-17 23:42:09'),(95,1000050,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',100.00,2,'2018-04-18 23:36:02'),(96,1000050,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,4,'2018-04-18 23:36:02'),(97,1000051,3,'55555555555','优益C','http://localhost:55178/images/636597775665914067.png',7.00,2,'2018-04-19 23:55:24'),(98,1000051,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',102.00,1,'2018-04-19 23:55:24'),(99,1000051,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,1,'2018-04-19 23:55:24'),(100,1000052,3,'55555555555','优益C','http://localhost:55178/images/636597775665914067.png',7.00,2,'2018-04-19 23:55:29'),(101,1000052,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',102.00,1,'2018-04-19 23:55:29'),(102,1000052,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,1,'2018-04-19 23:55:29'),(103,1000053,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',102.00,3,'2018-04-22 13:17:02'),(104,1000053,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,3,'2018-04-22 13:17:02'),(105,1000053,3,'55555555555','优益C','http://localhost:55178/images/636597775665914067.png',7.00,3,'2018-04-22 13:17:02'),(106,1000053,4,'77758854545','低温酸奶','http://localhost:55178/images/636599997618246337.png',3.50,3,'2018-04-22 13:17:02'),(107,1000054,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',102.00,1,'2018-04-22 13:28:46'),(108,1000054,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,8,'2018-04-22 13:28:46'),(109,1000054,3,'55555555555','优益C','http://localhost:55178/images/636597775665914067.png',7.00,6,'2018-04-22 13:28:46'),(110,1000054,4,'77758854545','低温酸奶','http://localhost:55178/images/636599997618246337.png',3.50,6,'2018-04-22 13:28:46'),(111,1000055,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',102.00,1,'2018-04-22 13:36:56'),(112,1000055,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,8,'2018-04-22 13:36:56'),(113,1000055,3,'55555555555','优益C','http://localhost:55178/images/636597775665914067.png',7.00,6,'2018-04-22 13:36:56'),(114,1000055,4,'77758854545','低温酸奶','http://localhost:55178/images/636599997618246337.png',3.50,6,'2018-04-22 13:36:56'),(115,1000056,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',102.00,1,'2018-04-22 13:40:36'),(116,1000056,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,1,'2018-04-22 13:40:36'),(117,1000056,3,'55555555555','优益C','http://localhost:55178/images/636597775665914067.png',7.00,7,'2018-04-22 13:40:36'),(118,1000056,4,'77758854545','低温酸奶','http://localhost:55178/images/636599997618246337.png',3.50,7,'2018-04-22 13:40:36'),(119,1000057,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',102.00,1,'2018-04-25 23:22:58'),(120,1000057,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,1,'2018-04-25 23:22:58'),(121,1000057,3,'55555555555','优益C','http://localhost:55178/images/636597775665914067.png',7.00,1,'2018-04-25 23:22:58'),(122,1000057,4,'77758854545','低温酸奶','http://localhost:55178/images/636599997618246337.png',3.50,1,'2018-04-25 23:22:58'),(123,1000058,1,'6934652192754','奶牛梦工厂原味','http://localhost:55178/images/636581121022115086.jpg',102.00,2,'2018-04-25 23:27:54'),(124,1000058,2,'323232323','安慕希','http://localhost:55178/images/636581121969365193.jpg',139.00,1,'2018-04-25 23:27:54'),(125,1000058,3,'55555555555','优益C','http://localhost:55178/images/636597775665914067.png',7.00,1,'2018-04-25 23:27:54'),(126,1000058,4,'77758854545','低温酸奶','http://localhost:55178/images/636599997618246337.png',3.50,1,'2018-04-25 23:27:54');
/*!40000 ALTER TABLE `order_record_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_region`
--

DROP TABLE IF EXISTS `order_region`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_region` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='区域';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_region`
--

LOCK TABLES `order_region` WRITE;
/*!40000 ALTER TABLE `order_region` DISABLE KEYS */;
INSERT INTO `order_region` VALUES (1,'九龙坡区'),(2,'南岸区'),(3,'渝中区'),(4,'江北区'),(5,'巴南区'),(6,'大渡口'),(7,'沙坪坝');
/*!40000 ALTER TABLE `order_region` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_shop`
--

DROP TABLE IF EXISTS `order_shop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_shop` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL COMMENT '便利店名称',
  `phone` varchar(20) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `linkman` varchar(20) DEFAULT NULL COMMENT '联系人',
  `address` varchar(100) DEFAULT NULL COMMENT '便利店地址',
  `region_id` int(11) DEFAULT NULL COMMENT '区域ID',
  `add_date` datetime DEFAULT NULL,
  `is_delete` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='便利店';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_shop`
--

LOCK TABLES `order_shop` WRITE;
/*!40000 ALTER TABLE `order_shop` DISABLE KEYS */;
INSERT INTO `order_shop` VALUES (1,'京东便利店','1853302022',NULL,'Mainly electronic','杨家坪西郊路-北大资源燕南5街区',3,'2018-04-19 23:03:56',0),(2,'711高科总部店1','18910012018',NULL,'张山','北部新区黄山大道64号',4,'2018-04-19 23:05:00',0),(3,'罗森大坪英利国际店','1312121212',NULL,'二狗','渝中区石油路',3,'2018-04-19 23:57:55',0);
/*!40000 ALTER TABLE `order_shop` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'order'
--

--
-- Dumping routines for database 'order'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-02 22:16:27
