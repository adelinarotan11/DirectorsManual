USE [Director'sManual]
--������ ��������� ����������:
INSERT INTO TCompany VALUES ('����� ��������','��.�������� 13','�������� ����� ����������');
INSERT INTO TCompany VALUES ('����� ������','��.������������� 22/70','��������� ���� ����������');
INSERT INTO TCompany VALUES ('�������� ��������','��.������a 6�','������ ���� �����������');
INSERT INTO TCompany VALUES ('����� �������','��.������� 11�','��������� ������� �������������');
SELECT * from TCompany
--������ ��������� ����������:
INSERT INTO TCustomer VALUES ('������ ����� ���������');
INSERT INTO TCustomer VALUES ('����� ��������� ������������');
INSERT INTO TCustomer VALUES ('������ �������� ���������');
INSERT INTO TCustomer VALUES ('������� ������ ������������');
INSERT INTO TCustomer VALUES('Laura Rutledge');
INSERT INTO TCustomer VALUES('Logan O. Fletcher');
INSERT INTO TCustomer VALUES('Avram Cervantes');
INSERT INTO TCustomer VALUES('Myles N. Kim');
INSERT INTO TCustomer VALUES('Denise C. Walter');
INSERT INTO TCustomer VALUES('Haviva S. Boyd');
INSERT INTO TCustomer VALUES('Alfreda Morales');
INSERT INTO TCustomer VALUES('Nadine K. Olsen');
INSERT INTO TCustomer VALUES('Kylan G. Doyle');
INSERT INTO TCustomer VALUES('Jesse Tran');
INSERT INTO TCustomer VALUES('Ainsley Branch');
INSERT INTO TCustomer VALUES('Stella Chase');
INSERT INTO TCustomer VALUES('Blake B. Woods');
INSERT INTO TCustomer VALUES('Davis Yates');
INSERT INTO TCustomer VALUES('Britanney Chaney');
SELECT * from TCustomer
--������ ��������� ����������:
INSERT INTO TProvider VALUES ('�������� ����� ����������');
INSERT INTO TProvider VALUES ('C������� ���� ���������');
INSERT INTO TProvider VALUES ('������� ���� �����������');
INSERT INTO TProvider VALUES ('��������� ������ �������������');
INSERT INTO TProvider VALUES ('�������� ������ ��������������');
INSERT INTO TProvider VALUES ('�������� ����� �������������');
SELECT * from TProvider

--������ ��������� ����������:
INSERT INTO TContract_product VALUES (1,4,17,111.00,'2019-11-04');
INSERT INTO TContract_product VALUES (19,1,87,145.90,'2019-11-04');
INSERT INTO TContract_product VALUES (2,2,654,237.90,'2019-11-04');
INSERT INTO TContract_product VALUES (3,2,17,9241.92,'2019-11-04');
INSERT INTO TContract_product VALUES (4,4,15,2877.19,'2019-04-04');
INSERT INTO TContract_product VALUES (18,2,31,3284.69,'2017-03-04');
INSERT INTO TContract_product VALUES (11,1,5,1832.10,'2017-11-04');
INSERT INTO TContract_product VALUES (9,2,15,2452.92,'2018-11-04');
INSERT INTO TContract_product VALUES (10,4,31,4711.12,'2020-11-04');
INSERT INTO TContract_product VALUES (5,4,5,1111.00,'2019-12-04');
INSERT INTO TContract_product VALUES (6,3,15,1455.90,'2019-11-04');
SELECT * from TContract_product

--������ ��������� ����������:
INSERT INTO TContract_detail VALUES (1,4,'2019-11-04',5,111.00);
INSERT INTO TContract_detail VALUES (4,1,'2019-11-04',15,145.90);
INSERT INTO TContract_detail VALUES (1,2,'2019-11-04',31,237.90);
INSERT INTO TContract_detail VALUES (6,4,'2019-11-04',5,924.92);
INSERT INTO TContract_detail VALUES (4,1,'2019-04-04',15,2877.19);
INSERT INTO TContract_detail VALUES (4,3,'2017-03-04',31,3284.69);
INSERT INTO TContract_detail VALUES (1,3,'2017-11-04',5,1832.10);
INSERT INTO TContract_detail VALUES (4,1,'2018-11-04',15,2452.92);
INSERT INTO TContract_detail VALUES (2,2,'2020-12-19',64,471.12);
INSERT INTO TContract_detail VALUES (1,4,'2019-12-04',5,111.00);
INSERT INTO TContract_detail VALUES (4,1,'2019-11-04',87,145.90);
INSERT INTO TContract_detail VALUES (5,2,'2019-06-04',100,31237.90);
INSERT INTO TContract_detail VALUES (1,4,'2019-11-04',17,924.92);
INSERT INTO TContract_detail VALUES (4,3,'2019-01-04',15,2877.19);
INSERT INTO TContract_detail VALUES (5,2,'2017-11-04',11,1035.44);
INSERT INTO TContract_detail VALUES (2,1,'2017-11-04',5,1832.10);
INSERT INTO TContract_detail VALUES (4,1,'2018-01-04',15,4005.30);
INSERT INTO TContract_detail VALUES (5,2,'2020-11-04',61,1504.36);
INSERT INTO TContract_detail VALUES (4,1,'2019-11-04',15,145.90);
INSERT INTO TContract_detail VALUES (1,2,'2019-06-04',31,237.90);
INSERT INTO TContract_detail VALUES (6,3,'2019-11-04',5,924.92);
SELECT * from TContract_detail

--������ ��������� ����������:
INSERT INTO TDetail VALUES (21,6,3,'�����');
INSERT INTO TDetail VALUES (1,1,4,'���� ');
INSERT INTO TDetail VALUES (2,4,1,'�����');
INSERT INTO TDetail VALUES (5,1,2,'������');
INSERT INTO TDetail VALUES (4,6,4,'������');
INSERT INTO TDetail VALUES (7,1,3,'������ ��������');
INSERT INTO TDetail VALUES (10,1,4,'��������');
INSERT INTO TDetail VALUES (11,4,1,'��� ');
INSERT INTO TDetail VALUES (17,4,1,'�������');
INSERT INTO TDetail VALUES (16,2,1,'������');
INSERT INTO TDetail VALUES (15,5,2,'������');
INSERT INTO TDetail VALUES (8,4,1,'�������');
INSERT INTO TDetail VALUES (10,1,4,'�������� ');
INSERT INTO TDetail VALUES (8,4,1,'��������');
INSERT INTO TDetail VALUES (7,1,3,'�����');
INSERT INTO TDetail VALUES (5,4,1,'������');
INSERT INTO TDetail VALUES (1,1,4,'������');
INSERT INTO TDetail VALUES (21,6,3,'�������');
SELECT * from TDetail

--������ ��������� ����������:
INSERT INTO TProduct VALUES 
(2,19,1,'����������� INDESIT DS 3181 W (UA)','������ � ����������
��������������� ����������� �� INDESIT �������� � ������� ������ �����, ������� �������� ���������� 185 � 60 � 64 ��, ��� ��������� ��� ���������� ��������� � �������� ���� ��������� �� ������� �����.','Technics',8199.99);
INSERT INTO TProduct VALUES (1,1,4,'��������� TRINX Majestic M116','TRINX MAJESTIC M116 � ����������� ���� � ���������� ��������� ������. C ������������� ��������� ������������ ����, ����� Disc. ����� ���������������, ��� ������� ����� ��� � ������� �������. ��������� TRINX MAJESTIC M116, ����������� � ���� ������. ������� ������ �������������� ���������� ������ ����� Shimano, ������ TZ, �������� ������������� ����� Trinx.
������� ����� 26 �����, ����� �������. �������������: ����������� ��������. ��� TRINX M116, ����� 14 ��.','Transport',7048.00);
INSERT INTO TProduct VALUES (11,18,3,'�������� ������� Dect Gigaset A116 Black','������������ ���  �������� ����� �� Gigaset Communications - ������������ DECT Gigaset A116 Black.
������ ������ �������� � ����  ����������� ����� �������, ��� �����-���� ���������. ���� �������� � ���������, �� ��� ������ ������� �� ������ ����� �� ��������� ���� ����� ���  ��������� � ��������� ������ ��������������.','Technics',559.70);
INSERT INTO TProduct VALUES (9,1,4,'����������� PHILIPS HD4731','19 ����������������� �������� � ������������ ����������� ����������� � ������� ������������ ������������ ���������� ��� ��������� ������������ � ������������� ��������� ����. ������� "����������� Pro"
��������� ����������� ����� � ����������� ������������� ������� �� ������ ������.','Household products',3100.99);
INSERT INTO TProduct VALUES (8,19,2,'���������� Renault Megane 2011','���������: 1.5 dCi
��� ���������: K9K 836/636
��� ���������: ���
��� �������: ������
����� ���������, ���.��: 1461
������������ ���������: ������
���������� ���������: 4
���������� ��������: 8
�����
������� ������: 15.5:1
��������, �.�.: 110
������� ����. ��������, ��./���.: 4000
�������� ������, ��: 240
������� ����. �������, ��./���.: 1750-2500','Transport',182240.00);
INSERT INTO TProduct VALUES (6,8,2,'������ BOSCH Tronic 1000 TR1000T 80 B','���������� ������������ ������� �������������� � ������� ���������� � ������� ��� ������� ���������������. ����� �������, ��� ��������� ����������� �� 70� ��������������� ����� ��������� ������������ �������� �������� ��� ������.
������ ��������������� Bosch Tronic ������ ������� ������ ���������� ��������������, ������������� � ����������� �������� Bosch.','Household products',2899.00);
INSERT INTO TProduct VALUES (3,12,2,'������� Profi SR 2-010-1','������ � �������� ��������� ������� ��� ����� � ������� � ������� �������� �����������.
�������� ������� � ������� ����������� ����� ������� ������ ������ �������� ����� � ����� �������������� �������� ����������� ��� ��������.','Transport',828.00);
INSERT INTO TProduct VALUES (4,13,2,'��������� ���� ZEVS PC A135','ZEVS PC A135 - ��� ������ �����  ��������� �������, � ������� �������������������. �������� PC A135 �� ���� ������������ �������������, ���������� � ���� ����������������� ��������� intel Pentium G620 (��� ������������� ������ i3)
� ���������� �������� + ����������� ����� �� ������������� ������ 1155. ����� ������� ��������, ��� ����������� ������� ���������������� � ���������� sandy bridge ������������ ������ ������� ������������������.','Accessories',7500.00);
INSERT INTO TProduct VALUES (10,14,4,'������� ACER Aspire 3 A315-55G','�������������� ����� ������ � ��� ��������, �������������� ���-�������� ��� ���������� ������� ������ ��������� ���������� Intel Core � ���������� NVIDIA GeForce MX230. ����� ��������� � ������ DDR4 �� 16 �� ����������� ����� ������� �������� �������� ����������, ������������ ������� � ����������� ������ � ������ ���������������.','Technics',15999.00);
INSERT INTO TProduct VALUES (5,14,4,'�������� Samsung Galaxy A10 A105F Red','������ � ��� ���� ��� ������ �������� �������� ���� � ������� Galaxy A10. �������� � ��������� ����������, � ����� ��������� �� �������, ����� ���������� ����� �����������. � �������� ���� ���������� ��������� � ����������, ��������� � �������� � ����� ��� ��������� ��� ��� ������ ����.','Technics',3199.00);
INSERT INTO TProduct VALUES (7,6,1,'���� ��������� ESPERANZA EBS008K','������ �� ������ �� ������ ����� �������������� ���� ���, �� ����� � �������� ���� �������� �������� �����������. ��� ������ �������� ��� ������ ������������ �� ����� �������������������� �������.','Technics',199.77);
INSERT INTO TProduct VALUES (2,19,1,'����������� INDESIT DS 3181 W (UA)','������ � ����������
��������������� ����������� �� INDESIT �������� � ������� ������ �����, ������� �������� ���������� 185 � 60 � 64 ��, ��� ��������� ��� ���������� ��������� � �������� ���� ��������� �� ������� �����.','Technics',8199.99);
select* from TProduct;

--������ ��������� ����������:
INSERT INTO TStockDetails VALUES (1,21,6,3,44);
INSERT INTO TStockDetails VALUES (2,1,1,4,17);
INSERT INTO TStockDetails VALUES (2,1,1,4,2);
INSERT INTO TStockDetails VALUES (3,2,4,1,29);
INSERT INTO TStockDetails VALUES (4,5,1,2,13);
INSERT INTO TStockDetails VALUES (5,4,6,4,61);
INSERT INTO TStockDetails VALUES (4,5,1,2,28);
INSERT INTO TStockDetails VALUES (6,7,1,3,41);
INSERT INTO TStockDetails VALUES (7,10,1,4,30);
INSERT INTO TStockDetails VALUES (18,21,6,3,12);
INSERT INTO TStockDetails VALUES (17,1,1,4,199);
INSERT INTO TStockDetails VALUES (15,7,1,3,22);
INSERT INTO TStockDetails VALUES (12,8,4,1,12);
INSERT INTO TStockDetails VALUES (16,5,4,1,199);
INSERT INTO TStockDetails VALUES (18,21,6,3,22);
SELECT * from TStockDetails

--������ ��������� ����������:
INSERT INTO TAssemblyProduct VALUES (2,4,1,4,2,5,'2019-11-08 19:00');
INSERT INTO TAssemblyProduct VALUES (2,15,1,4,2,13,'2019-12-08 19:00');
INSERT INTO TAssemblyProduct VALUES (11,11,4,14,5,4,'2018-11-05 15:00');
INSERT INTO TAssemblyProduct VALUES (11,6,4,14,5,5,'2018-11-05 15:00');
INSERT INTO TAssemblyProduct VALUES (3,15,3,6,11,3,'2019-02-11 13:00');
INSERT INTO TAssemblyProduct VALUES (8,14,2,2,3,13,'2019-04-08 19:00');
INSERT INTO TAssemblyProduct VALUES (6,13,2,19,8,2,'2018-11-05 15:00');
INSERT INTO TAssemblyProduct VALUES (5,12,4,11,9,6,'2019-10-04 17:30');
INSERT INTO TAssemblyProduct VALUES (10,1,4,7,10,7,'2019-11-08 19:00');
INSERT INTO TAssemblyProduct VALUES (3,13,3,6,11,4,'2019-02-11 13:00');
INSERT INTO TAssemblyProduct VALUES (4,11,4,1,9,6,'2019-11-04 17:30');
INSERT INTO TAssemblyProduct VALUES (1,3,4,1,1,2,'2019-11-08 19:00');
INSERT INTO TAssemblyProduct VALUES (12,2,1,5,7,50,'2018-11-05 15:00');
INSERT INTO TAssemblyProduct VALUES (2,5,1,4,2,1,'2018-11-05 15:00');
INSERT INTO TAssemblyProduct VALUES (7,7,2,13,6,3,'2019-12-08 19:00');
INSERT INTO TAssemblyProduct VALUES (2,11,1,3,2,4,'2019-12-08 19:00');
INSERT INTO TAssemblyProduct VALUES (6,6,2,2,8,15,'2019-10-04 17:30');
select* from TAssemblyProduct;

