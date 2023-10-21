# Identity

## CLI

```dotnet
$ dotnet new [mvc, webapi,..] -n <name> --auth Individual
```

## Getting Started with ASP.NET Identity

ASP.NET Identity system là design để thay thế ASP.NET Membership và Simple Membership. Nó gồm profile support, OAuth integration, OWIN.

## Introduction to ASP.NET Identity

ASP.NET membership system được giới thiệu vào 2005, và đã trải qua nhiều thay đổi trong các kiểu handle authentication và authorization. ASP.NET Identity is a fresh look của membership system khi bạn building ứng dụng web, phone, or table.

### Background: Membership in ASP.NET

#### ASP.NET Membership

ASP.NET Membership được design để solve các yêu cầu chung về membership, Forms Authentication và một SQL Server database để lưu trữ username, password và profile. Ngày ngay hầu hết các application yêu cầu cho phép sử dụng các social identity providers để authentication và authorization functionality. Những giới hạn của ASP.NET Membership làm cho việc chuyển tiếp khó khăn:

- Databse schema chỉ design dùng cho SQL Server. Bạn có thể thêm thông tin profile, nhưng khó thêm dữ liệu vào trong các bản khác, gây khó cho việc access và mong muốn hiểu về Profile Provider API.

- Hệ thống cho phép bạn thay đổi dữ liệu lưu trữ, nhưng hệ thống được designed xoay quanh một relational database. Bạn có thể ghi dữ liệu vào non-releational nhưng code sẽ có nhiều lỗi về `System.NotImplementdException` với các method không apply cho NoSQL database.
- Chức năng Login/Logout cơ bản từ Forms Authentication, không hỗ trợ sử dụng `OWIN`. OWIN bao gồm:

    - Middleware component for authentication.

    - Hỗ trợ login sử dụng các external identity providers (Microsof Accounts, Facebook, Google, Twitter).

    -  Login sử dụng các organizational accounts từ on-premises Active Derectory or Azure Active Directory.

    - OWIN cũng hỗ trợ OAuth 2.0 JWT và CORS.

#### ASP.NET Simple Membership

ASP.NET simple membership là membership system được phát triển để dùng cho ASP.NET Web Pages.  Mục đích của Simple Membership là dễ dàng thêm các chức năng membership trên ứng dụng Web Pages.

Simple Membership dẽ dàng customize user profile information,nhưng nó vẫn còn những hạn chế khác của ASP.NET Membership:

- Khó persist data khi lưu trữ trong một non-relational.

- Không sử dụng OWIN.

- Không làm việc tốt với ASP.NET Membership providers đã có, và không thể extensible.

#### ASP.NET Universal Providers

ASP.NET Universal Providers được phát triển để persist membership inforamtion in Microsoft Azure SQL Database, và làm việc tốt với SQL Server Compact. Nó được build trên Entity Framework Code First, nên ASP.NET Universal Providers có thể sử dụng persist data trong bất kỳ store support by EF.

ASP.NET Universal Providers được build trên ASP.NET Membership infrastructure, nên nó sẽ có giới hạn về SqlMembership Provider. Nó được design dành cho relational databasees và hard cutomize profile, user information.

### ASP.NET Identity

Là câu chuyện membership in ASP.NET đã được cải tiến trong những năm vừa qua, team ASP.NET đã học được từ nhiều feedback from customers.

Giả sử người dùng sẽ sign-in với username/password sau khi họ đã đăng ký thành công trên ứng dụng. Web có thể đến nhiều social. Người dùng có thể tương tác real-time với nhiều social channels như Facebook, Twitter, và các social web khác. Developers muốn cho phép người dùng interacting sign-in với social identity sẽ cần rất nhiều kinh nghiệm về web sites. Modern (Hiện tại) membership system cho phép redirection-based log-ins đến authentication providers như Facebook, Twitter, v/v..

ASP.NET đã phát triển với các mục đích sau:

- **One ASP.NET Identity system**

    - ASP.NET Identity có thể sử dụng cho tất cả ASP.NET framework như, ASP.NET MVC, Web Forms, Web Pages, Web API, SignalR.
    
    - ASP.NET Identity có thể sử dụng khi bạn building web, phone, store, or hybrid applications.

- **Ease of plugging in profile data about the user**

    - Bạn có thể control over schema của user và profile information. Ví dụ, bạn có thể dễ dàng cho phép hệ thống store birthday khi đăng ký account.

- **Persistence control**

    - Mặc định, ASP.NET Identity system sẽ stores all the user information in database. ASP.NET Identity uses Entity Framework Code First để thực thi all persistence mechanism.

    - Bạn có thể control database schema, common tasks như thay đổi table names hoặc thay đổi data type, ... có thể làm một cách dễ dàng.

    Dễ dàng plug in deffirent storage mechanisms như SharePoint, Azure Storage Table Service, NoSQL database, ... mà không throw `System.NotImplementdExceptions`.

- **Unit testability**

    - ASP.NET Identity làm cho web application more unit testable. Bạn có thể viết các unit test cho từng part của ứng dụng khi sử dụng ASP.NET Identity.

- **Role provider**

    - Role provider giúp bạn hạn chế truy cập (restrict access) các part của application by role. Bạn có thể dễ dàng tạo roles như "Admin" và add role cho users. 

- **Claims Based**

    - ASP.NET Identity supports claims-based authentication, nơi mà user's identity mô tả một set of claims. Claims allow developers trình bày nhiều inforamtion về user's identity hơn khi sử dụng role. Role membership là kiểu boolean (member or non-member), trong khi claim có thể gồm rich information khi nói về user's identity và membership.

- **Social Login Providers**

    - Bạn có thể dễ dàng add social log-ins như Microsoft Account, Facebook, Twitter, Google và các ứng dụng khác của bạn, và sotre user-specific data trong application của bạn.

- **OWIN integration**

    - Hiện tại ASP.NET authentication đang based trên OWIN middleware nên có thể sử dụng OWIN-based host. ASP.NET Identity không phụ thuộc vào `System.Web`. Nó có tuân thủ đầy đủ OWIN framework và có thể sử dụng trên OWIN host application.

    - ASP.NET Identity uses OWIN Authentication để log-in/log-out users trên web site. Hiểu là nó thay thế việc sử dụng Forms Authentication để tạo cookies, application uses OWIN CookieAuthentication để làm việc đó.

- **NuGet package**

    - ASP.NET Identity is redistributed trên các NuGet package được installed in ASP.NET MVC, Web Forms và Web API templates. Bạn có thể download NuGet package từ NuGet gallery.

    - Releasing ASP.NET Identity về new feature và bug fixes từ NuGet package sẽ giúp các developers update dễ dàng hơn.