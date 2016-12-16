ALTER TABLE Address
ADD CONSTRAINT [FK_Address_Person] 
FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])

ALTER TABLE Address
ADD CONSTRAINT [FK_Address_AddressType] 
FOREIGN KEY ([AddressTypeId]) REFERENCES [AddressType]([Id])


ALTER TABLE Contact
ADD CONSTRAINT [FK_Contact_Person] 
FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])

ALTER TABLE Contact
ADD CONSTRAINT [FK_Contact_ContactType] 
FOREIGN KEY ([ContactTypeId]) REFERENCES [ContactType]([Id])

