SET IDENTITY_INSERT AddressType ON

INSERT INTO AddressType (Id, ShortName, Inactive) VALUES (1, 'Home', 0)
INSERT INTO AddressType (Id, ShortName, Inactive) VALUES (2, 'Postal', 0)
INSERT INTO AddressType (Id, ShortName, Inactive) VALUES (3, 'Work', 0)

SET IDENTITY_INSERT AddressType OFF
