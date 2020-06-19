USE [Director'sManual]
--Скрипт занесения информации:
INSERT INTO TCompany VALUES ('Завод Малышева','ул.Ломизова 13','Труханов Игорь Валерьевич');
INSERT INTO TCompany VALUES ('Завод Ильича','ул.Азовстальская 22/70','Васильева Юлия Николаевна');
INSERT INTO TCompany VALUES ('Компатия Техноопт','ул.Чкаловa 6а','Иванов Юрий Степановичь');
INSERT INTO TCompany VALUES ('Завод Хартрон','ул.Межевая 11б','Николаева Людмила Константинова');
SELECT * from TCompany
--Скрипт занесения информации:
INSERT INTO TCustomer VALUES ('Ковалёв Мирон Данилович');
INSERT INTO TCustomer VALUES ('Попов Александр Авксентьевич');
INSERT INTO TCustomer VALUES ('Гуляев Корнелий Никитевич');
INSERT INTO TCustomer VALUES ('Соколов Любовь Авксентьевич');
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
--Скрипт занесения информации:
INSERT INTO TProvider VALUES ('Труханов Игорь Валерьевич');
INSERT INTO TProvider VALUES ('Cтепанов Илья Сергеевич');
INSERT INTO TProvider VALUES ('Стрелец Юлия Анатольевна');
INSERT INTO TProvider VALUES ('Николаева Милена Константинова');
INSERT INTO TProvider VALUES ('Николаев Максим Константинович');
INSERT INTO TProvider VALUES ('Миронова Илона Константинова');
SELECT * from TProvider

--Скрипт занесения информации:
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

--Скрипт занесения информации:
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

--Скрипт занесения информации:
INSERT INTO TDetail VALUES (21,6,3,'Балка');
INSERT INTO TDetail VALUES (1,1,4,'Винт ');
INSERT INTO TDetail VALUES (2,4,1,'Гайка');
INSERT INTO TDetail VALUES (5,1,2,'Гвоздь');
INSERT INTO TDetail VALUES (4,6,4,'Дюбель');
INSERT INTO TDetail VALUES (7,1,3,'Колесо зубчатое');
INSERT INTO TDetail VALUES (10,1,4,'Боковина');
INSERT INTO TDetail VALUES (11,4,1,'Вал ');
INSERT INTO TDetail VALUES (17,4,1,'Воронка');
INSERT INTO TDetail VALUES (16,2,1,'Гильза');
INSERT INTO TDetail VALUES (15,5,2,'Дверца');
INSERT INTO TDetail VALUES (8,4,1,'Демпфер');
INSERT INTO TDetail VALUES (10,1,4,'Задвижка ');
INSERT INTO TDetail VALUES (8,4,1,'Заклепка');
INSERT INTO TDetail VALUES (7,1,3,'Зацеп');
INSERT INTO TDetail VALUES (5,4,1,'Каркас');
INSERT INTO TDetail VALUES (1,1,4,'Клапан');
INSERT INTO TDetail VALUES (21,6,3,'Колодка');
SELECT * from TDetail

--Скрипт занесения информации:
INSERT INTO TProduct VALUES 
(2,19,1,'Холодильник INDESIT DS 3181 W (UA)','ДИЗАЙН И эргономика
Комбинированный холодильник от INDESIT выполнен в корпусе белого цвета, размеры которого составляют 185 х 60 х 64 см, что позволяет ему гармонично вписаться в интерьер даже небольшой по площади кухни.','Technics',8199.99);
INSERT INTO TProduct VALUES (1,1,4,'Велосипед TRINX Majestic M116','TRINX MAJESTIC M116 – алюминиевая рама с внутренней проводкой тросов. C механическими тормозами облегченного типа, класс Disc. Вилка амортизационная, это придает малый вес и больший комфорт. Велосипед TRINX MAJESTIC M116, выпускается в пяти цветах. Оснащен задним переключателем начального уровня фирмы Shimano, модель TZ, передний переключатель марки Trinx.
Диаметр колес 26 дюйма, обода двойные. Дополнительно: парковочная подножка. Вес TRINX M116, около 14 кг.','Transport',7048.00);
INSERT INTO TProduct VALUES (11,18,3,'Домашний телефон Dect Gigaset A116 Black','Представляем Вам  новейший товар от Gigaset Communications - радиотелефон DECT Gigaset A116 Black.
Данная модель включает в себя  необходимый набор функций, без каких-либо излишеств. Если говорить в сравнении, то эта модель выходит на первые места по розничной цене когда идёт  сравнение с аналогами других производителей.','Technics',559.70);
INSERT INTO TProduct VALUES (9,1,4,'Мультиварка PHILIPS HD4731','19 предустановленных программ с оптимальными настройками температуры и нагрева обеспечивают превосходные результаты при обработке ингредиентов и приготовлении различных блюд. Функция "Мультиповар Pro"
позволяет настраивать время и температуру приготовления вручную на разных этапах.','Household products',3100.99);
INSERT INTO TProduct VALUES (8,19,2,'Автомобиль Renault Megane 2011','Двигатель: 1.5 dCi
Код двигателя: K9K 836/636
Тип двигателя: ДВС
Тип топлива: Дизель
Объем двигателя, куб.см: 1461
Расположение цилиндров: Рядное
Количество цилиндров: 4
Количество клапанов: 8
Турбо
Степень сжатия: 15.5:1
Мощность, л.с.: 110
Обороты макс. мощности, об./мин.: 4000
Крутящий момент, Нм: 240
Обороты макс. момента, об./мин.: 1750-2500','Transport',182240.00);
INSERT INTO TProduct VALUES (6,8,2,'Бойлер BOSCH Tronic 1000 TR1000T 80 B','Управление температурой нагрева осуществляется с помощью регулятора в корпусе под крышкой водонагревателя. Таким образом, при установке температуры до 70С водонагреватель будет постоянно поддерживать заданное значение при работе.
Каждый водонагреватель Bosch Tronic покрыт изнутри слоями уникальной стеклокерамики, разработанной в лаборатория компании Bosch.','Household products',2899.00);
INSERT INTO TProduct VALUES (3,12,2,'Самокат Profi SR 2-010-1','Модный и стильный городской самокат для детей с надёжной и простой системой складывания.
Стильный самокат с прочной алюминиевой рамой поможет малышу весело провести время и будет способствовать развитию координации его движений.','Transport',828.00);
INSERT INTO TProduct VALUES (4,13,2,'Системный блок ZEVS PC A135','ZEVS PC A135 - это прежде всего  недорогое решение, с хорошей производительностью. Построен PC A135 на базе оригинальных комплектующих, включающих в себя энергоэффективный процессор intel Pentium G620 (это корпоративная версия i3)
с встроенной графикой + материнская плата на перспективном сокете 1155. Сразу хочется отметить, что эффективные функции энергосбережения и технология sandy bridge обеспечивают сборке высокую производительность.','Accessories',7500.00);
INSERT INTO TProduct VALUES (10,14,4,'Ноутбук ACER Aspire 3 A315-55G','Воспроизводите видео быстро и без задержек, просматривайте веб-страницы или выполняйте рабочие задачи благодаря процессору Intel Core и видеокарте NVIDIA GeForce MX230. Такое сочетание и память DDR4 до 16 ГБ гарантируют более высокую скорость загрузки приложений, качественную графику и эффективную работу в режиме многозадачности.','Technics',15999.00);
INSERT INTO TProduct VALUES (5,14,4,'Смартфон Samsung Galaxy A10 A105F Red','Теперь у вас есть еще больше способов выразить себя с помощью Galaxy A10. Создайте и настройте селфимоджи, а потом отправьте их друзьям, чтобы поделиться своим настроением. И украсьте свои фотографии стикерами с селфимоджи, фильтрами и штампами — пусть они расскажут все без лишних слов.','Technics',3199.00);
INSERT INTO TProduct VALUES (7,6,1,'Весы напольные ESPERANZA EBS008K','Теперь вы можете не только легко контролировать свой вес, но также и украсить свою квартиру стильным аксессуаром. Для вашего удобства все данные отображаются на ярком жидкокристаллическом дисплее.','Technics',199.77);
INSERT INTO TProduct VALUES (2,19,1,'Холодильник INDESIT DS 3181 W (UA)','ДИЗАЙН И эргономика
Комбинированный холодильник от INDESIT выполнен в корпусе белого цвета, размеры которого составляют 185 х 60 х 64 см, что позволяет ему гармонично вписаться в интерьер даже небольшой по площади кухни.','Technics',8199.99);
select* from TProduct;

--Скрипт занесения информации:
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

--Скрипт занесения информации:
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

