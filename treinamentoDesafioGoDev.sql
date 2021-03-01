-- MySQL Script generated by MySQL Workbench
-- Sat Feb 27 12:49:47 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema TreinamentoDesafioGoDev
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema TreinamentoDesafioGoDev
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `TreinamentoDesafioGoDev` DEFAULT CHARACTER SET utf8 ;
-- -----------------------------------------------------
-- Schema new_schema1
-- -----------------------------------------------------
USE `TreinamentoDesafioGoDev` ;

-- -----------------------------------------------------
-- Table `TreinamentoDesafioGoDev`.`Pessoas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TreinamentoDesafioGoDev`.`Pessoas` (
  `Nome` VARCHAR(50) NOT NULL,
  `Sobrenome` VARCHAR(50) NOT NULL,
  `SalaE1` VARCHAR(50) NOT NULL,
  `SalaE2` VARCHAR(50) NOT NULL,
  `Cafe1` VARCHAR(50) NOT NULL,
  `Cafe2` VARCHAR(50) NOT NULL,
  `TrocarSala` TINYINT(1) NOT NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TreinamentoDesafioGoDev`.`Salas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TreinamentoDesafioGoDev`.`Salas` (
  `Nome` VARCHAR(50) NOT NULL,
  `Lotação` INT NOT NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TreinamentoDesafioGoDev`.`Espacos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TreinamentoDesafioGoDev`.`Espacos` (
  `Nome` VARCHAR(50) NOT NULL,
  `Lotação` INT NOT NULL)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
