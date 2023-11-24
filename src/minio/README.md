# MinIO

## .NET Client API Reference

[Tài liệu tham khảo](https://min.io/docs/minio/linux/developers/dotnet/API.html# "Tài liệu tham khảo")

## Study case

### Download tất cả các file trong Bucket

Tham khảo API GetListsAsync

Bước 1: Kiểm tra Bucket có tồn tại không?
Bước 2: Lấy tất objects trong Bucket sử dụng `WithRecursive(true)` để files trong sub folder
Bước 3: Download lần lược file sử dụng `GetObjectAsync` với tên file lấy từ `item.Key` trong list object bên trên.
