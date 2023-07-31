# RPS
Тестовая работа
 #### \RPS - back NET.Core
 RPS.API - API и вход в систему__
 RPS.Contracts - описание контрактов для работы__
 RPS.Infrastructure - реализация работы с дынными__
 RPS.Application - уровень бизнес логики__
 
 Чтобы стартовать проект надо запустить RPS.API - откроется swagger__
 Использую подход CQRS(на основе MediatR) и подход чистой архитектуры, уровень Application не занет о реализации работы с данными, только интерфейсы из RPS.Contracts.__
 База данных - Microsoft.EntityFrameworkCore.InMemory__
 Для преобразования моделей использую AutoMapper__
 Для валидации - FluentValidation__
 Логирование - Serilog__
 
 #### \rps-front - front angular
 Релизованно на angular16__
 Использую Ngrx для работы со сотоянием приложения.__
 Нужен angular cli__
 
 Чтобы запустить:__
 npm i__
 ng serve__
 
 В файле environments.ts, хранится ссылка на api (apiUrl), если поменятся путь к back, то надо поправить.__
 По умолчанию запускается по пути: http://localhost:4200/game__
 

