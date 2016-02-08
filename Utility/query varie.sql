Deliverable FINALE 
Query 1 
/*Query per ottenere Vertici A e B a partire dal nome del vertice e dal tipo dell'albero*/ 
SELECT A.VertexUid, A.Depth, B.VertexUid, B.Depth FROM Vertex A, Vertex B 
WHERE A.Type = Type_albero passato da c# AND 
A.Name = Nome_vertice passato da c# AND 
B.Type = Type_albero passato da c# AND 
B.Name = Nome_vertice passato da c#; 
 
Query 2 
/*Query per ottenere l'Edge a partire dal suo UID*/ 
SELECT * FROM Edge 
WHERE EdgeUid = EdgeUid passato da c#; 
 
Query 3 
/*Query per ottenere Vertex a partire dal suo UID*/ 
SELECT * FROM Vertex 
WHERE VertexUid = VertexUid passato da c#; 
 
Query 4 
/*Query per ottenere l'elenco degli attributi di un Vertice/Edge a partire dal suo UID*/ 
SELECT AD.AttDefUid, AD.Name, AU.AttrValue FROM AttrDef AD, AttrUsage AU 
WHERE AU.ObjectUid = VertexUid o EdgeUid passato da c# AND 
AU.AttrDefUid = AD.AttrDefUid; 
 
Query 5 
/*Query per inserire la definizione degli attributi*/ 
INSERT INTO AttrDef VALUES (newid(), 'PTime'); 
INSERT INTO AttrDef VALUES (newid(), 'Cost'); 
 
Query 6 
/*Query per inserire i valori degli attributi relativi ai vertici e agli archi*/ 
INSERT INTO AttrUsage VALUES (newid(), VertexUid/EdgeUid passato da c#, AttrDefUid passato da c#, '[valore]');  