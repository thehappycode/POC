# RabbitMQ

## Install RabbitMQ

[Tham khảo cài đặt RabbitMQ tại đây](https://www.rabbitmq.com/download.html "Install RabbitMQ")

Cài đặt RabbitMQ chạy trên docker:

```docker
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.12-management
```

**Lưu ý:** *Thay thay đổi phiên bản rabbitmq khi install*

## 1. Hello World

![Atl Hello World](../GetStarted/imgs/hello-world.png "Hello World")

## 2. Worker Queues

!["Atl Worker Queues"](../GetStarted/imgs/work-queues.png "Worker Queues")

### Round-robin dispatching

Mặc định RabbitMQ sẽ chia tuần tự message cho danh sách consonmers.  Việc distributing messages này gọi là round-robin. Cần lưu ý round-robin khi scale consumer.

### Message acknowledgment

Khi RabbitMQ chuyển một message đến consumer thì nó sẽ ngay lập tức đánh dấu đã xoá lên message đó. Trường hợp có sự cố như consumer chết khi đang xử lý thì message đấy sẽ bị mất. Để khắc phục vấn đề này RabbitMQ hỗ trợ `message acknowledgments`. Ack (acknowledgment) sẽ sendback từ consumer đến RabbitMQ để nói message đã được received, processed, khi đấy RabbitMQ mới được xoá nó.

Nếu consumer chết (như đóng chanel, mất connection, hoặc TCP mất kết nối) thì ack sẽ không sendback, khi đó RabbitMQ sẽ hiểu là message chưa processed xong và message sẽ được đưa trở lại queue. Khi đấy message sẽ không bị mất. Timeout mặc định là 30 phút, bạn có thể [tăng thời gian timeout](https://www.rabbitmq.com/consumers.html#acknowledgement-timeout) tại đây

Khi dùng `Acknowledgment` ưu điểm là *không mất message*, nhưng cũng có nhược điểm là *tốn rất nhiều bộ nhớ (RAM)*

### Message durability

Chúng ta đã học được cách làm cho các message không bị mất khi *consumer chết*. Nhưng nếu RabbitMQ server dừng thì message vẫn sẽ bị mất.

Khi RabbitMQ thoát hoặc crashes, nó sẽ quên hết queues và messages. Để không mất message trong trường hợp này sau khi restart RabbitMQ, chúng ta sẽ đánh dấu `durable` cho cả queues và messages. Chúng ta cũng cần đánh dấu messages là `persistent`

### Fair (Phiên) Dispatch

Case thực tế sẽ có những dispatch không mong muốn như sau. Chúng ta có 2 consumers, khi tất cả message lẻ rất nặng và message chẳn lại rất nhẹ. Khi đó consumer lẻ sẽ luôn rất bận trong khi consumer chẳn lại rất nhàn. Bởi vì RabbitMQ sẽ dispatch message vào trong queue theo cơ chế `round-robin dispatch` nó sẽ không biết được số unacknowledged message của consumer nên sẽ dispatch mỗi n-th message đến n-th consumer.

!["Atl Prefetch Count"](../GetStarted/imgs/prefetch-count.png "Prefetch Count")

Bạn có thể setting `prefetchCount = 1` trong method `BasicQos`, để nói cho RabbitMQ biết là trong một thời điểm không có nhiều hơn một message trong một consumer. Hay nói cách khác là không dispatch một new message cho đến khi consumer processed và acknowledged message trước đó. Thay vào đó, RabbitMQ sẽ dispatch new message đến consumer tiếp theo nếu nó không bận.

Nếu tất cả consumer đều bạn thì bạn nên cân nhắc tăng thêm số consumers hoặc sử dụng một chiến lược khác.

## 3. Publish/Subscrible

### Exchanges

!["Atl Exchanges"](../GetStarted/imgs/exchanges.png "Exchanges")

Producer không bao giờ chuyển trực tiếp các messages đến queue. Thay vào đó producer sẽ chuyển messages đến `exchange`.

Exchange gồm có các kiểu: `direct`, `topic`, `headers`, `fanout`.

### Temporary queues

### Bindings

!["Atl Bindings"](../GetStarted/imgs/bindings.png "Bindings")

Mối quan hệ giửa exchange và queue chúng ta gọi là `binding`.

## 4. Routing

Routing là việc điều hướng các message đến đúng các subscribe theo `routingKey`.

### Extra Bindings

Như đã biết từ mục trước `bindings` là mối liên hệ giữa exchange và queue. Hay đơn giản queue là thừa hưởng các message từ exchange.

Tham số `routingKey` phụ thuộc vào loại exchange. Với `fanout` exchanges nó đơn giản sẽ bỏ qua giá trị của `routingKey`

### Direct exchange

Khi sử dụng `direct` exchange thì message đến queues sẽ phải exactly matches với `routingKey` của message. Nếu message không exactly matches thì sẽ discarded.

!["Atl Direct Exchange"](../GetStarted/imgs/direct-exchange.png "Direct Exchange")

### Multiple bindings

!["Atl Multiple bindings"](../GetStarted/imgs/direct-exchange-multiple.png "Multiple bindings")

## 5. Topics

### Topic exchange

Cũng giống như `direct` exchange các message đến queues phải matches với `routingKey` tuy nhiên sẽ có một số lưu ý quan trọng sau:

- `routingKey` của `topic` exchange có thể là danh sách các từ, được xác định bởi các dấu `chấm`.
- `*` (start) tương ứng với một từ
- `#` (hash) tương ứng với không hoặc nhiều từ

!["Alt Topic Exchange"](../GetStarted/imgs/topic-exchange.png "Topic Exchange")

Từ hình ảnh ta có thể thấy:

- Q1 sẽ có binding key `*.orange.*` nghĩa là Q1 sẽ nhận message với `routingKey` phải có 3 từ trong đó bắt buộc từ thứ 2 phải là `orange`
- Q2 sẽ có binding key `*.*.rabbit` và `lazy.#` nghĩa là Q2 sẽ nhận message với `routingKey` có ít nhất 2 từ và bắt buộc từ thứ nhất là `lazy` hoăc từ thứ 3 là `rabbit`

## 6. Remote producer call (RPC)

Trong bài *2. WorkerQueues* chúng ta đã học distribute nhiều messages trong cùng một thời gian thì sẽ phụ thuộc vào nhiều consumers.

Nhưng nếu chúng ta cần đợi **kết quả** trả về thì đó làm một câu chuyện khác. Khi đó chúng ta sử dụng pattern common có tên là `Remote Procedure Call` hay là `RPC`

Để build môt `RPC` system gồm:

- Một client
- Một scalable RPC server

### Client interface

Trong RPC service chúng ta tạo ra một simple client class, sẽ export một phương thức có tên là `CallAsync` sẽ send một RPC request và block cho đến khi nhận được kết quả từ received.

### Callback queue

RPC sẽ over RabbitMQ một cách dễ dàng. Client send một request message và đợi server replies một response message. Trong khi receive chờ order một response chúng ta cần send một `callback` đến queue address của request.

### CorrelationId

Ở đây có một vấn đề, khi client nhận response từ queue, thì sẽ không biết được send từ request nào. Khi đó chúng ta cần sử dụng một property `CorrelationId` và set giá trị là `unique` cho mỗi lần request. Nếu không biết giá trị của `CorrelationId`, chúng ta sẽ discard message đó vì nó không thuộc bất kỳ request nào.

Tại sao chúng ta lại discard message? Để tránh trường hợp bị duplicate response trong use case: Khi `RPC` server chết sau khi đã processed và reply kết quả cho client nhưng chưa kịp `acknowledgment message` về queue. Khi restart lại server thì `RPC` server sẽ processing lại message trên dẫn đến tình trạng bị duplicate.

### Summary

!["Alt RPC"](../GetStarted/imgs/rpc.png "RPC")

- Khi client start, nó sẽ thực thi và tạo ra một anonymous callback queue
- Một RPC request, client send một message với 2 propterties:
  - `ReplyTo`: Set callback queue.
  - `CorrelationId`: Set giá trị unique cho mỗi request.
- Request send đến `rpc_queue` queue.
- RPC server luôn chờ một request từ queue. Khi môt request xuất hiện, nó xử lý logic và send một message để trả kết quả về client khi sử dụng queue property `ReplyTo`
- Client đợi dữ data từ callback queue. Khi message xuất hiện, nó sẽ check `CorrelationId` property. Nếu matches đúng giá trị với `CorrelationId` của request nó sẽ trả response về application.
- Callback queue sẽ bị xóa sau khi response.
