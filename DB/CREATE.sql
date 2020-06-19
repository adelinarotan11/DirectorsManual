USE [Director'sManual]
--скрипт создания таблицы:
CREATE TABLE TCompany
(
  ID int PRIMARY KEY IDENTITY,
  Name_C VARCHAR(80) NOT NULL,
  Address_C VARCHAR(100) NOT NULL,
  FIO_Director VARCHAR(100) NOT NULL,
);
CREATE TABLE TCustomer--Покупатель
(
  ID int PRIMARY KEY IDENTITY,
  Name_Customer VARCHAR(100) NOT NULL
);
CREATE TABLE TProvider--Поставщик
(
  ID int PRIMARY KEY IDENTITY,
  Name_prov nvarchar(100) NOT NULL
);
CREATE TABLE TContract_product--Договор на отпуск готовых товаров
(
  ID int PRIMARY KEY IDENTITY,
  CustomerID int FOREIGN KEY REFERENCES TCustomer(ID) NOT NULL,
  CompanyID int FOREIGN KEY REFERENCES TCompany(ID) NOT NULL,
  Kolvo_Products INT NOT NULL,
  Price_Product REAL NOT NULL,
  Date_delivery_product DATE
);
CREATE TABLE TContract_detail--Договор на приобретение деталей
(
  ID int PRIMARY KEY IDENTITY,
  ProviderID int FOREIGN KEY REFERENCES dbo.TProvider(ID) NOT NULL,
  CompanyID int FOREIGN KEY REFERENCES dbo.TCompany(ID) NOT NULL,
  Date_delivery_detail DATE,
  Kolvo_Detail INT  NOT NULL,
  Price_detail REAL  NOT NULL
);
CREATE TABLE TDetail
(
  ID int PRIMARY KEY IDENTITY,
  Contract_detailID int FOREIGN KEY REFERENCES dbo.TContract_detail(ID) NOT NULL,
  ProviderID int FOREIGN KEY REFERENCES dbo.TProvider(ID) NOT NULL,
  CompanyID int FOREIGN KEY REFERENCES dbo.TCompany(ID) NOT NULL,
  Name_Detail VARCHAR(40) NOT NULL
);
CREATE TABLE TProduct--Товар
(
  ID int PRIMARY KEY IDENTITY,
  Contract_productID int FOREIGN KEY REFERENCES dbo.TContract_product(ID) NOT NULL,
  CustomerID int FOREIGN KEY REFERENCES dbo.TCustomer(ID) NOT NULL,
  CompanyID int FOREIGN KEY REFERENCES dbo.TCompany(ID) NOT NULL,
  Name_Product VARCHAR(40) NOT NULL,
  [Description] NVARCHAR(1000) NOT NULL,
  [Category] NVARCHAR(50) NOT NULL,
  [Price] DECIMAL(16, 2) NOT NULL,
  ImageData VARBINARY(MAX) NULL,
  ImageMimeType	VARCHAR(50) NULL

);
CREATE TABLE TStockDetails--Склад деталей
(
  ID int PRIMARY KEY IDENTITY,
  DetailID int FOREIGN KEY REFERENCES dbo.TDetail(ID) NOT NULL,
  Contract_detailID int FOREIGN KEY REFERENCES dbo.TContract_detail(ID) NOT NULL,
  ProviderID int FOREIGN KEY REFERENCES dbo.TProvider(ID) NOT NULL,
  CompanyID int FOREIGN KEY REFERENCES dbo.TCompany(ID) NOT NULL,
  KolvoDetail INT  NOT NULL

);

CREATE TABLE TAssemblyProduct--Сборка товара
(
  ID int PRIMARY KEY IDENTITY,
  ProductID int FOREIGN KEY REFERENCES TProduct(ID) NOT NULL,
  StockDetailsID int FOREIGN KEY REFERENCES TStockDetails(ID) NOT NULL,
  CompanyID int FOREIGN KEY REFERENCES TCompany(ID) NOT NULL,
  CustomerID int FOREIGN KEY REFERENCES TCustomer(ID) NOT NULL,
  Contract_productID int FOREIGN KEY REFERENCES TContract_product(ID) NOT NULL,
  Kolvo_Needed_Details INT  NOT NULL,
  Date_assembly_Product  DateTime 
);