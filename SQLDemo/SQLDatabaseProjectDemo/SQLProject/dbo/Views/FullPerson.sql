CREATE VIEW [dbo].[FullPerson]
	AS
	SELECT [p].[FirstName], [p].[LastName], 
		   [a].[Id] AS AddressId, [a].[StreetAddress], [a].[City], [a].[State], [a].[ZipCode]
	FROM dbo.Person p
	LEFT JOIN dbo.Address a ON p.Id = a.PersonId
