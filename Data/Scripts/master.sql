SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

CREATE DATABASE IF NOT EXISTS `tm470` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `tm470`;

CREATE TABLE `versioned_beers` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `unique_beer_id` int(10) NOT NULL,
  `version` int(11) NOT NULL,

  PRIMARY KEY (`id`)
);

CREATE TABLE `unique_beers` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `country_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,

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
SELECT unique_beers.id, versioned_beers.id as 'beer_id', unique_beers.name, countries.country, versioned_beers.version  
FROM unique_beers
INNER JOIN countries
ON unique_beers.country_id = countries.id
INNER JOIN versioned_beers
ON unique_beers.id = versioned_beers.unique_beer_id
ORDER BY versioned_beers.id ASC;