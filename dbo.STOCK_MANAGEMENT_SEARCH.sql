CREATE PROCEDURE STOCK_MANAGEMENT_SEARCH
	@stock_name varchar(10),
	@tank_name varchar(30),
	@id_location int,
	@valid_from Datetime,
	@valid_to Datetime,
	@include_cancelled char(1),
	@stock_number varchar(10)

AS 
BEGIN
	SELECT s.id_stock, 
		   s.id_location,
		   s.stock_number, 
		   capacity, 
		   status, 
		   location_name, 
		   id_tank, 
		   tank_name, 
		   quantity, 
		   convert(varchar, valid_from, 106), 
		   convert(varchar, valid_to, 106),
		   status
	FROM stock s 
	INNER JOIN tank t ON s.id_stock = t.id_stock 
	INNER JOIN location l ON s.id_location = l.id_location 
	WHERE s.stock_number = isnull(@stock_number, s.stock_number) 
		  AND isnull(t.valid_from,'20010101') >= isnull(@valid_from, '20010101')
		  AND isnull(t.valid_to,'21000101') <= isnull(@valid_to, '21000101')
		  AND s.status = (CASE WHEN @include_cancelled = 'Y' THEN s.status ELSE 'A' END)
END