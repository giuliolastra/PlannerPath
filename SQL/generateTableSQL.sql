create table Vertex   
(   
VertexUid uniqueidentifier,   
Name varchar(100),   
Type varchar(100),   
Depth int,   
PreviousEdgeUid uniqueidentifier,   
CONSTRAINT [Vertex_pk] PRIMARY KEY CLUSTERED    
  
(   
    [VertexUid] ASC   
)   
  
)   

  
/*creazione tabella Edge*/ 
 
create table Edge   
(   
EdgeUid uniqueidentifier,   
StartVertexUid uniqueidentifier,   
EndVertexUid uniqueidentifier,   
CONSTRAINT [Edge_pk] PRIMARY KEY CLUSTERED    
(   
    [EdgeUid] ASC   
)   
   
)   
   alter table Edge add  default (newsequentialid()) FOR EdgeUid   
   
ALTER TABLE Edge  WITH CHECK ADD  CONSTRAINT [EndVertex_to_Edge] FOREIGN KEY([EndVertexUid])   
REFERENCES [Vertex] ([VertexUid])   
   
ALTER TABLE Edge  WITH CHECK ADD  CONSTRAINT [StartVertex_to_Edge] FOREIGN KEY([StartVertexUid])   
REFERENCES [Vertex] ([VertexUid])   

alter table Vertex add  default (newsequentialid()) FOR VertexUid 
ALTER TABLE Vertex  WITH CHECK ADD  CONSTRAINT [PreviousEdge_to_Vertex] FOREIGN KEY([PreviousEdgeUid])   
REFERENCES [Edge] ([EdgeUid])   
   
   
 
/*creazione tabella AttrDef*/   
   
create table AttrDef   
(   
    AttrDefUid uniqueidentifier,   
    Name varchar(50),   
CONSTRAINT [AttrDef_pk] PRIMARY KEY CLUSTERED    
(   
    [AttrDefUid] ASC   
)   
)   
   
alter table AttrDef add  default (newsequentialid()) FOR AttrDefUid   
   
   
/*creazione tabella AttrUsage*/ 
 
create table AttrUsage   
(   
    AttrUsageUid uniqueidentifier,   
    ObjectUid uniqueidentifier,   
    AttrDefUid uniqueidentifier ,  
    AttrValue varchar(1000),   
CONSTRAINT [AttrUsage _pk] PRIMARY KEY CLUSTERED    
(   
    [AttrUsageUid] ASC,   
    [ObjectUid] ASC   
)   
   
)   
   
alter table AttrUsage add  default (newsequentialid()) FOR AttrUsageUid   
  
ALTER TABLE Vertex  WITH CHECK ADD  CONSTRAINT [Vertex_to_PreviousEdge] FOREIGN KEY([PreviousEdgeUid])   
REFERENCES [Edge] ([EdgeUid]) 