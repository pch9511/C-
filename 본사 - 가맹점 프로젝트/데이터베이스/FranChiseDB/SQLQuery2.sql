/*Select * From [LoginLog] Order by [Time] desc

Select * From [LoginLog] Where [Id] = '123456' AND [Time] IN (Select MAX([Time]) From [LoginLog] Where [Log] = '�α���')

Select * From [Mail] Where [RegiNum] = '123456' AND [Date] IN (Select MAX([Date]) From [Mail])

Select * From [Mail]*/

--INSert INTO [MAil] Values('123456','Admin','Test','�׽�Ʈ���Դϴ�.',GetDate())

/*CREATE TABLE [dbo].[Category]
(
	[Id] NvarChar(3) NOT NULL PRIMARY KEY,
	[Name] NvarChar(20) NOT NULL,
	[Level] Int NOT NULL,
	[Parent] NvarChar(20) NULL
)*/
--SELECT * FROM [Order] Where [State] Like '%��û�ź�%'

--Select * From Category
--Select * From Product
--Delete From Product Where Id = 'A000'
--Select * From Itemback
--Select * From HeadStock


--Select * From [FranchiseInfo]

--Delete From HeadStock
--Select * From HeadStock
--Select * From FranStock Order by [Date] Desc 
--Select [RegiNum],Sum(Account * Price) as '�� ���Ծ�', Sum(Account) as '�� ���Լ���' From FranStock Where State ='�԰�' Group by [RegiNum]
--Select * From Product
--Select RegiNum,Sum(Account * -OutPrice) as �����Ѿ�,[Pay] From HeadStock Where State ='���' Group by [RegiNum],[Pay]
--Select RegiNum,Sum(Account * OutPrice) as ��ǰ�Ѿ� From [ItemBack] Group by [RegiNum]
--Select [Id],Sum(Account * InPrice) as �����Ѿ�,Sum(Account) as ���� From HeadStock Where State ='�԰�' Group by [Id]
--Select [Id],Sum(Account * -OutPrice) as �����Ѿ�,Sum(-Account) as ���� From HeadStock Where State ='���' Group by [Id]
--Select [Id],Sum(Account * OutPrice) as ��ǰ�Ѿ�,Sum(Account) as ����,[State] From [ItemBack] Group by [Id],[State]
--Delete From FranStock Where Account=20000
--Drop Table HeadStock
--Delete From [Product]
--Drop Table [Order]
--Delete From [Order]
--Select * From [Order]
--Select * From [ItemBack]
--Select * From [Menu]
--Delete From Pay
--Select * From Pay Order by [Date] Asc
--Select * From SellProduct Order by [Date] Asc
--Select * From FranStock Where 
--Select * From [SellProduct]
--Select Top(5) [Name],Sum(Account) as �Ǹŷ� From [SellProduct] Group by [Name]

--Select * From [Mail]

--Select * From [LoginLog]
--Select * From Mail	
--Select * From ChatLog Order By [Date] Asc
--Delete From ChatLog
--Select [RegiNum],[Name],[Price],[Date] From FranStock
                --Where RegiNum = '123456' UNION  
                --Select [RegiNum],[Content],[Price],[Date] From Pay Where RegiNum = '123456' Order by [Date] Asc

--Select * From ChatLog
--Select [Id],[Name],[InPrice] ,sum(Account) as Account From HeadStock Group By [Id],[Name],[InPrice] Order by Account asc
--Delete From ChatRoom

--Select * From ChatRoom
--Select * From Mail

--Insert INTO category Values('C','Test','3','Test')

--DELETE From Category
--ALTER TABLE [Category] ADD [Parent] NvarChar(20) NULL;

--DROP TABLE Category 


/*CREATE TABLE [dbo].[Return]
(
	����
	��ǰ�ڵ�
	��ǰ��
	����
	����
	��ǰ���� 
	������
)*/


--Select [Id],[Name],[InPrice],[OutPrice],[Account],[Date],[State],[Pay] From [HeadStock]
--union
--Select * From [HeadStock] Order by [Date] asc
--Update Top(1) [HeadStock] Set State = '�ҷ�' Where State = '���' 
--Select * From [HeadStock] Order by [Date] asc
--Update Top(1) [HeadStock] Set State = '���' Where [State] = '�ҷ�' and [Id] = 'BDA000' and [Account] = '-100' and [OutPrice] = '1800'
--Delete From [ORder]
--Delete From [HeadStock] Where [State] = '��ǰ'
--Delete TOp(1) From [ItemBack]

--Select * From [Order]
--Update [HeadStock] Set State = '���' Where [Date] = '2023-06-13 11:45:06.810'
--Update [Order] Set [State] = '��ǰ��û : �ҷ�'  Where [State] = '��ǰ�Ϸ�'
--Select * From [Itemback]
