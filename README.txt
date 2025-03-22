Hotel Management System (HMS)

General description

App has to be made using ASP.NET Core Web API technology, where client must be able to manage hotels and data related to it.

We must work on following entities:

Hotel(Id PK, Name, Rating in range of 1-5, Country, City, Adress)

Room(Id PK, Name, IsFree(bool), Price)

Manager(Id PK Identity, Name, SurName, IdentityNumber, Email, MobileNumber)

Guest(Id PK Identity, , Name, SurName, IdentityNumber, MobileNumber)

Reservation(Id PK Identity, CheckInDate, CheckOutDate)

We must use all three types of table relationships (1 to 1, 1 to many, many to many).
Relations logic is following:

Hotel has to have only one manager and manager is able to manage one hotel. (1 to 1)
Hotel has many rooms and these rooms belong to this hotel only. (1 to many)
Any hotel should be able to make any amount of reservations. For example, group reservation or individual. (many to many)

Business requirements:

1. Hotel
*Create hotel
*Update hotel details - posibility to update name, adress and rating.
*Rating validation - rating must be from 1 to 5.
*Delete hotel - hotel must be deleted if it has no active rooms or active reservations.
*Get hotels - posibility to filter hotels via country, city and rating.
*Get hotel by Id.

2. Room
*Create room - room has to be tied to hotel.
*Room status management - Free or occupied.
*Price validation - price must be more than 0.
*Update room details - possibility to change name, status and price.
*Delete room - possibility to delete room if it has no active reservation.
*Room filtering - possibility to filter room via hotel, status and price range.

3.Manager
*Manager registration - Manager must have unique email and identity number.
*Update manager - possibility to update name, surname, email and mobile number.
*Binding manager to hotel - each hotel has to have minimum one manager.
*Delete Manager - possibility to delete manager only if hotel has another manager.
*Authorization and Authentification - Managers must authorize, before getting access to HMS.

4.Guest
*Guest registration - guest must have unique identity number and mobile number.
*Update guest details
*Delete guest - guest can be deleted only if it has no active reservation.

5.Reservation
*Create reservation - guest can only book room with free status. Checkin date must be current date or future date. Checkout date must be later than checkin date. In the end of booking operation, room status should change to occupied.
*Update reservation - Only dates can be changed. New dates should not intersect with other reservation dates for this room.
*Delete reservation - Room status must change to free.
*Search reservation - possibility to filter reservation by hotel, guest, room or dates. possibility to see active and completed reservations.

System roles:
1.Administrator (system administrator)
2.User(guest which can make reservation)
3.Manager(hotel manager)

Essential technical requirements:

1. MSSQL Server
2. ORM - Entity Framework Core Code First (Data Seed, Migrations)
3. Split app into logical components, for example (Service Layer, Repository Layer, Presentation Layer)
4. Global Ecxeption Handling Middleware
5. Genereic Repository
6. Role Based Identity Authentication
7. Role Based Identity Authorization
8. JWT Token
9. Auto mapper
10. Each endpoint must be secured with according roles. Endpoints can be affected by different roles, maybe only by managers, or users, or admins or there might be mixed access.(this part is confusing for me as well, i might not translate this well).
11. Similar Response in any case, doesn't matter request is succesfull or not.(this part is ambigious for me)
12. Microsoft Dependency Injection.

HINT

Every endpoint must start with hotel. There is no need to make separate controllers for each entity. Below is shown example of how endpoint adresses must be represented

For example, how looks GET request for hotel, manager, rooms

For hotel - (Get one hotel) => /api/hotel/{hotelId}
For room - (Get one room ) => /api/hotels/{hotelId}/rooms/{roomId}
For manager (Get manager) => /api/hotels/{hotelId}/Managers/{managerId}
