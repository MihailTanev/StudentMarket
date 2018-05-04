USE StudentWebMarket_db

CREATE NONCLUSTERED INDEX IX_Products_Name
ON dbo.Products (Name);

CREATE NONCLUSTERED INDEX IX_Category_Name
ON dbo.Categories(Name);