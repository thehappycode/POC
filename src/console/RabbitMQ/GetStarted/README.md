## 2 Worker Queues

### Round-robin dispatching

Mặc định RabbitMQ sẽ chia tuần tự message cho danh sách consonmers.  Việc distributing messages này gọi là round-robin. Cần lưu ý round-robin khi scale consumer.

### Message acknowledgment

Khi RabbitMQ chuyển một message đến consumer thì nó sẽ ngay lập tức đánh dấu đã xoá lên message đó. Trường hợp có sự cố như consumer chết khi đang xử lý thì message đấy sẽ bị mất. Để khắc phục vấn đề này RabbitMQ hỗ trợ `message acknowledgments`. Ack (acknowledgment) sẽ sendback từ consumer đến RabbitMQ để nói message đã được received, processed, khi đấy RabbitMQ mới được xoá nó.

Nếu consumer chết (như đóng chanel, mất connection, hoặc TCP mất kết nối) thì ack sẽ không sendback, khi đó RabbitMQ sẽ hiểu là message chưa processed xong và message sẽ được đưa trở lại queue. Khi đấy message sẽ không bị mất. Timeout mặc định là 30 phút, bạn có thể [tăng thời gian timeout](https://www.rabbitmq.com/consumers.html#acknowledgement-timeout) tại đây