CREATE DATABASE TestDB;
GO

use TestDB
GO

CREATE TABLE Data (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(255) NOT NULL
);
GO

INSERT INTO Data (title) VALUES
('(Seed) The Daily'),
('(Seed) Radiolab'),
('(Seed) 99% Invisible'),
('(Seed) Stuff You Should Know'),
('(Seed) Reply All'),
('(Seed) Freakonomics Radio'),
('(Seed) The Tim Ferriss Show'),
('(Seed) How I Built This'),
('(Seed) Science Vs'),
('(Seed) Planet Money');

GO