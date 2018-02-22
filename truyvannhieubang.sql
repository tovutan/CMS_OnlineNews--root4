select title,p.Id,u.AuthorName,c.name  from Post p inner join category c on p.Id=c.id join [User] u on p.CreateBy=u.id


select *From Post_Category_Mapping pcm  
join post p on pcm.PostId=p.id 
join Category c on c.Id=pcm.CategoryId 
join [user] u on u.id=p.CreateBy

select * from dbo.[user]