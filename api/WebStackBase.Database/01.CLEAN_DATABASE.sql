-- Desactivar restricciones de claves foráneas para eliminar datos
EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

-- Eliminar los datos en el orden correcto (tablas hijas primero)
DELETE FROM ReservationDetail;  -- Dependiente de Reservation, Service
DELETE FROM ServiceResource;    -- Dependiente de Resource, Service
DELETE FROM TokenMaster;        -- Dependiente de User
DELETE FROM [User];               -- Dependiente de Role

-- Eliminar los datos de las tablas padres (después de las hijas)
DELETE FROM Reservation;        -- No tiene dependencias hacia otras tablas
DELETE FROM Service;            -- No tiene dependencias hacia otras tablas
DELETE FROM Resource;           -- No tiene dependencias hacia otras tablas
DELETE FROM Role;               -- No tiene dependencias hacia otras tablas

-- Reseed de las tablas con columnas 'IDENTITY' para reiniciar el contador
DBCC CHECKIDENT ('ReservationDetail', RESEED, 0);
DBCC CHECKIDENT ('ServiceResource', RESEED, 0);
DBCC CHECKIDENT ('TokenMaster', RESEED, 0);
DBCC CHECKIDENT ('User', RESEED, 0);
DBCC CHECKIDENT ('Reservation', RESEED, 0);
DBCC CHECKIDENT ('Service', RESEED, 0);
DBCC CHECKIDENT ('Resource', RESEED, 0);
DBCC CHECKIDENT ('Role', RESEED, 0);

-- Activar las restricciones de claves foráneas nuevamente
EXEC sp_MSforeachtable "ALTER TABLE ? CHECK CONSTRAINT ALL";
