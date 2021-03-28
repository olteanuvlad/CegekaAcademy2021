

INSERT INTO [Brands]([Name])
VALUES 
	('Suzuki'),
	('Toyota'),
	('Mazda');

INSERT INTO [Models]([Name], [Brand_Id], [Base_Price])
VALUES
	('Vitara',  1, 16900),
	('Corolla', 2, 19825),
	('CX-5', 3, 25270);

INSERT INTO [PossibleFeatures]([Model_Id], [Package_Name], [Engine_Size_CC], [Fuel], [Transmission], [Gearbox], [HorsePower], [Price])
VALUES
	(1, 'Passion', 1400, 'HYBRID', 'ALL_WHEEL_DRIVE', 'MANUAL', 129, 3750),
	(1, 'Spirit', 1400, 'HYBRID', 'FRONT_WHEEL_DRIVE', 'AUTOMATIC', 129, 3250),
	(2, 'Dynamic', 1500, 'GASOLINE', 'FRONT_WHEEL_DRIVE', 'AUTOMATIC', 123, 225),
	(2, 'GR Sport', 1800, 'HYBRID', 'FRONT_WHEEL_DRIVE', 'AUTOMATIC', 121, 3675),
	(3, 'Emotion', 2000, 'GASOLINE', 'FRONT_WHEEL_DRIVE', 'MANUAL', 165, 0),
	(3, 'Revolution', 2500, 'GASOLINE', 'FRONT_WHEEL_DRIVE', 'AUTOMATIC', 194, 8430),
	(3, 'Takumi Plus', 2500, 'GASOLINE', 'ALL_WHEEL_DRIVE', 'AUTOMATIC', 194, 12630);

INSERT INTO [Inventory]([Model_Id], [Actual_Features_Id], [Manufacture_Date])
VALUES
	(1, 1, CONVERT(DATETIME, '02/12/2019', 103)),
	(1, 2, CONVERT(DATETIME, '28/12/2019', 103)),
	(2, 3, CONVERT(DATETIME, '02/02/2020', 103)),
	(2, 4, CONVERT(DATETIME, '03/03/2020', 103)),
	(3, 5, CONVERT(DATETIME, '01/01/2021', 103)),
	(3, 6, CONVERT(DATETIME, '02/02/2021', 103)),
	(3, 7, CONVERT(DATETIME, '03/03/2021', 103));

INSERT INTO [Customers]([Firstname], [Lastname])
VALUES
	('Vlad', 'Olteanu'),
	('Ion', 'Popescu');

INSERT INTO [CustomerBuys]([Customer_Id], [Inventory_Id], [Date])
VALUES
	(2, 1, SYSDATETIME());

INSERT INTO [CustomerInterests]([Customer_Id], [Model_Id], [Date])
VALUES
	(1, 3, SYSDATETIME());

SELECT M.[Name] as 'Model', B.[Name] as 'Brand' 
FROM  Inventory AS I 
	JOIN Models as M ON I.Model_Id=M.Id 
	JOIN Brands AS B ON M.Brand_Id = B.Id
GROUP BY M.[Name], B.[Name];

SELECT 
	B.[Name] AS "Brand",
	M.[Name] AS "Model",
	P.[Package_Name] AS "Package",
	Year(I.[Manufacture_Date]) AS "Year manufactured",
	P.[Engine_Size_CC] AS "Engine size",
	P.[Fuel] AS "Fuel",
	P.[Transmission] AS "Transmission",
	P.[Gearbox] AS "Gearbox",
	P.[HorsePower] AS "Horsepower",
	(M.[Base_Price]+P.[Price]) AS "Price"
FROM PossibleFeatures AS P 
	JOIN Inventory AS I ON P.Id=I.Actual_Features_Id
	JOIN Models AS M ON I.Model_Id = M.Id
	JOIN Brands AS B ON M.Brand_Id = B.Id
WHERE M.[Name] = 'Vitara';

SELECT
	P.[Package_Name] AS "Package", 
	P.[Engine_Size_CC] AS "Engine size",
	P.[Fuel] AS "Fuel",
	P.[Transmission] AS "Transmission",
	P.[Gearbox] AS "Gearbox",
	P.[HorsePower] AS "Horsepower",
	P.[Price] AS "Price"
FROM PossibleFeatures AS P
	JOIN Models AS M ON P.Model_Id = M.Id
WHERE
	M.[Name] = 'CX-5';

SELECT DISTINCT C.Firstname, C.Lastname
FROM Customers AS C
	JOIN CustomerBuys AS B ON C.Id = B.Customer_Id
WHERE
	B.Date >= DATEADD(month, -1, GETDATE());

SELECT DISTINCT C.Firstname, C.Lastname
FROM Customers AS C
	JOIN CustomerInterests AS I ON C.Id = I.Customer_Id
WHERE
	I.Date >= DATEADD(month, -1, GETDATE());

SELECT
	B.[Name] AS "Brand",
	M.[Name] AS "Model",
	P.[Package_Name] AS "Package", 
	Year(I.[Manufacture_Date]) AS "Year manufactured",
	P.[Engine_Size_CC] AS "Engine size",
	P.[Fuel] AS "Fuel",
	P.[Transmission] AS "Transmission",
	P.[Gearbox] AS "Gearbox",
	P.[HorsePower] AS "Horsepower",
	(M.[Base_Price]+P.[Price]) AS "Price"
FROM Brands B JOIN Models M ON B.Id = M.Brand_Id
	JOIN Inventory I ON M.Id = I.Model_Id
	JOIN PossibleFeatures P ON I.Actual_Features_Id = P.Id
WHERE
	YEAR(Manufacture_Date) = '2020';

SELECT
	B.[Name] AS "Brand",
	M.[Name] AS "Model",
	M.[Base_Price] AS "Base price"
FROM Models M JOIN Brands B ON M.Brand_Id = B.Id
WHERE
	M.[Base_Price] BETWEEN 16000 AND 25000;

SELECT
	B.[Name] AS "Brand",
	M.[Name] AS "Model",
	P.[Package_Name] AS "Package", 
	Year(I.[Manufacture_Date]) AS "Year manufactured",
	P.[Engine_Size_CC] AS "Engine size",
	P.[Fuel] AS "Fuel",
	P.[Transmission] AS "Transmission",
	P.[Gearbox] AS "Gearbox",
	P.[HorsePower] AS "Horsepower",
	(M.[Base_Price]+P.[Price]) AS "Price"
FROM Brands B JOIN Models M ON B.Id = M.Brand_Id
	JOIN Inventory I ON M.Id = I.Model_Id
	JOIN PossibleFeatures P ON I.Actual_Features_Id = P.Id
WHERE
	FUEL = 'GASOLINE';

