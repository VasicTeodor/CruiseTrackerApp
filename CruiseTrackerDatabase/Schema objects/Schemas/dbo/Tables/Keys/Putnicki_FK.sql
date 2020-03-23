ALTER TABLE Putnicki
ADD CONSTRAINT Putnicki_Brod_FK FOREIGN KEY
(
idBroda
)
REFERENCES Brod
(
idBroda
)