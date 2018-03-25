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
-- Table structure for table `order_goods`
--

DROP TABLE IF EXISTS `order_goods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_goods` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `brand_id` int(11) DEFAULT NULL,
  `goods_img` varchar(200) DEFAULT NULL,
  `goods_code` varchar(45) DEFAULT NULL,
  `goods_name` varchar(200) DEFAULT NULL,
  `goods_spec` varchar(45) DEFAULT NULL,
  `goods_unit` varchar(45) DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT '商品状态',
  `add_time` date DEFAULT NULL,
  `last_update_time` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='商品表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_goods`
--

LOCK TABLES `order_goods` WRITE;
/*!40000 ALTER TABLE `order_goods` DISABLE KEYS */;
INSERT INTO `order_goods` VALUES (1,3,'/img/pic.jpg','6934652192754','奶牛梦工厂原味','150g','杯',1,'0001-01-01',NULL);
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
  `id` int(11) NOT NULL,
  `goods_id` varchar(45) DEFAULT NULL COMMENT '商品ID',
  `goods_price` decimal(10,0) DEFAULT NULL COMMENT '商品价格',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品价格表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_goods_price`
--

LOCK TABLES `order_goods_price` WRITE;
/*!40000 ALTER TABLE `order_goods_price` DISABLE KEYS */;
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
  `amount` int(11) DEFAULT NULL COMMENT '商品数量',
  `add_date` date DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT '订单状态',
  `end_date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='订单记录表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_record`
--

LOCK TABLES `order_record` WRITE;
/*!40000 ALTER TABLE `order_record` DISABLE KEYS */;
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
  `goods_id` varchar(45) DEFAULT NULL,
  `goods_name` varchar(45) DEFAULT NULL,
  `goods_img` varchar(45) DEFAULT NULL,
  `goods_price` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='订单记录详情表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_record_detail`
--

LOCK TABLES `order_record_detail` WRITE;
/*!40000 ALTER TABLE `order_record_detail` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='区域';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_region`
--

LOCK TABLES `order_region` WRITE;
/*!40000 ALTER TABLE `order_region` DISABLE KEYS */;
INSERT INTO `order_region` VALUES (1,'九龙坡区'),(2,'南岸区');
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
  `address` varchar(100) DEFAULT NULL COMMENT '便利店地址',
  `region_id` int(11) DEFAULT NULL COMMENT '区域ID',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='便利店';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_shop`
--

LOCK TABLES `order_shop` WRITE;
/*!40000 ALTER TABLE `order_shop` DISABLE KEYS */;
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

-- Dump completed on 2018-03-25 22:16:16
