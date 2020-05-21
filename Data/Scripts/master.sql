SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

CREATE DATABASE IF NOT EXISTS `tm470` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `tm470`;

CREATE TABLE `beers` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `country_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `version` int(11) NOT NULL,

  PRIMARY KEY (`id`)
);

CREATE TABLE `beer_collection` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL,
  `beer_id` int(11) NOT NULL,

  PRIMARY KEY (`id`)
);

CREATE TABLE `countries` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `country` varchar(50) NOT NULL,

  PRIMARY KEY (`id`)
);

CREATE TABLE `friends` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL,
  `friend_id` varchar(255) NOT NULL,
  `nickname` varchar(255) NOT NULL,

  PRIMARY KEY (`id`)
);


CREATE  OR REPLACE VIEW `beersViewModel` AS
SELECT beers.id, beers.name, countries.country, beers.version  
FROM beers
INNER JOIN countries 
ON beers.country_id = countries.id
ORDER BY beers.id ASC;