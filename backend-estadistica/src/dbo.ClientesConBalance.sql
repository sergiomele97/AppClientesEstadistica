 CREATE VIEW [dbo].[ClientesConBalance] AS
 SELECT 
     c.ClienteId,
     c.Nombre,
     c.Edad,
     c.Sexo,
     p.Nombre AS Pais,
     (SELECT ISNULL(SUM(t.ImporteRecibido), 0) 
      FROM Transaccion t 
      WHERE t.ClienteDestinoId = c.ClienteId) 
      - 
     (SELECT ISNULL(SUM(t.ImporteEnviado), 0) 
      FROM Transaccion t 
      WHERE t.ClienteOrigenId = c.ClienteId) 
     AS Balance,
     (SELECT COUNT(*) 
      FROM Transaccion t 
      WHERE t.ClienteOrigenId = c.ClienteId) 
     AS NumeroGastos,
     (SELECT COUNT(*) 
      FROM Transaccion t 
      WHERE t.ClienteDestinoId = c.ClienteId) 
     AS NumeroIngresos
 FROM Clientes c
 INNER JOIN Pais p ON c.PaisId = p.PaisId