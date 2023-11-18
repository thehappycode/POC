# Session ID

## Tài liệu tham khảo

https://www.seobility.net/en/wiki/Session_ID
https://www.geeksforgeeks.org/session-vs-token-based-authentication/
https://www.educative.io/answers/session-based-authentication-vs-token-based-authentication
https://viblo.asia/p/session-va-token-based-authentication-yMnKMNbNZ7P
https://viblo.asia/p/su-khac-biet-giua-xac-thuc-dua-tren-session-va-token-1VgZvQ19KAw

## Mở đầu

Xin chào tất cả anh em, hôm nay chúng ta sẽ nói về sesionId?

- SesionId là gì?
- Bao nhiêu loại sesions? và cách thức hoạt động của từng loại?

Trước khi đi vào định nghĩa sesionId, thì ta sẽ có một ví dụ về thương mại điện tử sau:
Anh em khi mua sắm online thì đều biết đến tính năng giỏ hàng (cart). Vào trang web bất kỳ ví dụ như vnshop vào chọn mua 1 số sản phẩm, mỗi lần chọn mua thì sp sẽ được thêm vào giỏ hàng ("quá dễ cho những ai có xèng :)").

- Case 1: Chọn mua xong thanh toán luôn (trường họp các bà vk).
- Case 2: Chọn mua xong để đấy hoặc tắt trình duyệt đi (trường hợp các ông ck).

Câu hỏi đặt ra là làm sao để server biết được một request đến từ client là của user nào? Để có thể thanh toán đúng?  ==> Để giải quyết vấn đề này thì các tiền bối về khoa học máy tính đã nghĩ ra cái gọi là "sesionId".


## Session ID là gì?

Dịch ra tiếng Việt là "phiên làm việc".
SessionId là unique number được sever gán cho client qua quá trình request. Id này dùng để định nghĩa (identify) và đánh dấu (track) user đang hoạt động

## Các loại sesionId?

### Cookies

### URL Parameter

### Hiden From Field

## User cases of Session IDs

- User authentication
- Shopping carts in E-commerce
- Personalization
- Analytics and tracking
- State management in web apps

## Sesion Management Best Practices

- Secure session ID generation
- Session expiration
- Cookies security
- Preventing session fixation
- Data encryption
- Monitoring and Logging

## Alternatives to session ID

- Tokens
- Cookies
- Local storage
- OAuth