# Задание от AutoDoc

### !!! Специально для AutoDoc, функционал был развернут на домашнем сервере https://autodoc.wishflow.ru/swagger/index.html

Создать REST API для работы с задачами.

1. Задача имеет поля: дата, наименование, статус выполнения. Задача может содержать несколько файлов.

2. API должен позволять работать с задачами (добавлять, удалять, обновлять, получать) и файлами. Учитывать, что файл может быть большим (в районе 100мб).

3. API может быть использован в разных клиентах (сайт, мобильные приложения). Задач может быть много (несколько тысяч).

4. Решение должно быть слабосвязанным, с выделенными слоями.

5. API должен иметь тестовый интерфейс в браузере (swagger или аналогичный). БД должна содержать тестовые данные.  Рекомендуется использовать .NET 5.0 или выше, БД MSSQL и какую-то ORM.

# В рамках задания было реализовано:

### 1. Проектирование архитектуры с разделением слоев

![image](https://user-images.githubusercontent.com/21026083/190452272-05ccf50b-c0cf-486b-82c5-137eaa4b30d7.png)

### 2. Проектирование базы данных с использованием подхода CodeFirst

![image](https://user-images.githubusercontent.com/21026083/190452615-34bf4381-a920-439c-a6ba-13b23061b343.png)


### 3. Разделение логики на команды и операции по считыванию (CQRS)

Был использован фреймворк MediatR для команд и сервисы по считыванию данных.
Таким образом, бизнес-логика получилась слабо-связанной.

![image](https://user-images.githubusercontent.com/21026083/190453243-e4bcdac4-8639-4adc-8d26-6ca84d9edb0c.png)


### 4. Валидация входящих данных

Был использован фреймворк FluentValidation

![image](https://user-images.githubusercontent.com/21026083/190453345-4b950fa4-52fc-40f5-9b8b-71ed9fa0994a.png)


### 5. Контроллеры.

В контроллерах не содержится никакой логики. По своей сути, они являются проводником

![image](https://user-images.githubusercontent.com/21026083/190453508-88423598-3a68-4262-b31a-4d71efe923cd.png)


### 6. Конечный итог

В рамках задания, было реализовано 11 методов, которые можно вызвать через Swagger UI (адрес в начале) или, например, Postman.
По мимо прочего, интегрировать разработанное API со своими приложениями.

#### Функционал:

##### Функционал по работе с задачами

Функционал по работе с задачами обеспечивает все CRUD операции

![image](https://user-images.githubusercontent.com/21026083/190454364-6740163c-110d-4576-b722-c0a32ec2528a.png)

##### Функционал по работе с файлами

Функционал по работе с задачами обеспечивает все CRUD операции
###### По мимо прочего, реализована функция для скачивания файла (по ID в бд)

![image](https://user-images.githubusercontent.com/21026083/190454591-85a3b7df-be8a-4255-8f1e-5ac89f6e0b2d.png)



