
-- Tabla para almacenar la información de los nodos
CREATE TABLE InformacionNodo (
    InformacionNodoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    CantidadVehiculos INT DEFAULT 0,
    TipoViaNorte NVARCHAR(50),
    TipoViaSur NVARCHAR(50),
    TipoViaEste NVARCHAR(50),
    TipoViaOeste NVARCHAR(50),
    Semaforo BIT DEFAULT 0,  -- 0 = False, 1 = True
    EstadoSemaforo NVARCHAR(20) DEFAULT 'Rojo',
    TiempoPromedioTransito INT DEFAULT 0
);

-- Tabla para almacenar los nodos de intersección y sus conexiones
CREATE TABLE NodoInterseccion (
    NodoID INT IDENTITY(1,1) PRIMARY KEY,
    InformacionNodoID INT NOT NULL,
    NodoNorteID INT NULL,
    NodoSurID INT NULL,
    NodoEsteID INT NULL,
    NodoOesteID INT NULL,
    EsNodoCentral BIT DEFAULT 0, -- Para identificar el nodo central
    FOREIGN KEY (InformacionNodoID) REFERENCES InformacionNodo(InformacionNodoID),
    FOREIGN KEY (NodoNorteID) REFERENCES NodoInterseccion(NodoID),
    FOREIGN KEY (NodoSurID) REFERENCES NodoInterseccion(NodoID),
    FOREIGN KEY (NodoEsteID) REFERENCES NodoInterseccion(NodoID),
    FOREIGN KEY (NodoOesteID) REFERENCES NodoInterseccion(NodoID)
);

 --SELECT * FROM InformacionNodo
 --SELECT * FROM NodoInterseccion