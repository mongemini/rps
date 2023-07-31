# RPS
Тестовая работа
 #### \RPS - back NET.Core
 RPS.API - API и вход в систему\
 RPS.Contracts - описание контрактов для работы\
 RPS.Infrastructure - реализация работы с дынными\
 RPS.Application - уровень бизнес логики\
 
 Чтобы стартовать проект надо запустить RPS.API - откроется swagger\
 Использую подход CQRS(на основе MediatR) и подход чистой архитектуры, уровень Application не занет о реализации работы с данными, только интерфейсы из RPS.Contracts.\
 База данных - Microsoft.EntityFrameworkCore.InMemory\
 Для преобразования моделей использую AutoMapper\
 Для валидации - FluentValidation\
 Логирование - Serilog\
 
 #### \rps-front - front angular
 Релизованно на angular16\
 Использую Ngrx для работы со сотоянием приложения.\
 Нужен angular cli\
 
 Чтобы запустить:\
 npm i\
 ng serve\
 
 В файле environments.ts, хранится ссылка на api (apiUrl), если поменятся путь к back, то надо поправить.\
 По умолчанию запускается по пути: http://localhost:4200/game\
 

