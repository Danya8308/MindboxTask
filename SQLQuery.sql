Select p.name as Product, c.name as Category from Products p 
left join ProductCategories pc on p.id = pc.ProductId
left join Categories c on pc.CategoryId = c.Id