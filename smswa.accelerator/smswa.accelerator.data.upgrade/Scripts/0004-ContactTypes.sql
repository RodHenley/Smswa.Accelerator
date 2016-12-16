SET IDENTITY_INSERT ContactType ON

INSERT INTO ContactType (Id, ShortName, Inactive) VALUES (1, 'Work Email', 0)
INSERT INTO ContactType (Id, ShortName, Inactive) VALUES (2, 'Personal Email', 0)
INSERT INTO ContactType (Id, ShortName, Inactive) VALUES (3, 'Work Phone', 0)
INSERT INTO ContactType (Id, ShortName, Inactive) VALUES (4, 'Personal Phone', 0)

SET IDENTITY_INSERT ContactType OFF
