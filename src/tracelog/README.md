# TraceLog

TraceLog phân tán sử dụng cả API và RabbitMQ.

## Flow

Một request từ Source sẽ được gán một correlationId vào header. Mục đích sẽ lưu correclationId vào trong file log để tracing.

## Projects

### Correlation

Thư viện sinh ra CorrelationId

### Dentination

WebApi nhận request từ Source hoặc sẽ tiêu thụ các message có gắn correlationId

### Source

WebApi gửi request có correctionId trong header hoặc đã gắn correlationId vào message.