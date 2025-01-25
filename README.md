# Chat Application - Client & Server với C# và Socket

## Giới thiệu

Ứng dụng này được xây dựng bằng ngôn ngữ C# sử dụng thư viện `System.Net.Sockets`, cho phép nhắn tin và trao đổi dữ liệu giữa **server** và nhiều **client**. Các tính năng chính bao gồm:

- Nhắn tin qua lại giữa server và nhiều client.
- Hỗ trợ gửi **icon** (emoji) trong tin nhắn.
- Hỗ trợ gửi file giữa server và client.
- Tương thích nhiều kết nối client cùng lúc.

---

## Tính năng

1. **Nhắn tin qua lại:**
   - Server và client có thể gửi và nhận tin nhắn văn bản trong thời gian thực.

2. **Hỗ trợ nhiều client:**
   - Server có thể quản lý và trao đổi tin nhắn với nhiều client cùng lúc.

3. **Gửi icon:**
   - Người dùng có thể gửi các biểu tượng cảm xúc phổ biến (emoji) qua giao diện chat.

4. **Gửi file:**
   - Hỗ trợ gửi file từ server đến client và ngược lại.

---

## Hạn chế

- **Lỗi gửi ảnh:**
  - Hiện tại, khi gửi ảnh qua socket, đôi lúc xảy ra lỗi làm mất dữ liệu hoặc hiển thị sai ảnh.

---

## Ảnh Demo

### Giao diện demo
![Giao diện Client](./Client/images/demo.png)

---

## Cách chạy ứng dụng

1. Clone hoặc tải project về máy.
2. Mở project trong Visual Studio hoặc IDE hỗ trợ C#.
3. Khởi chạy **Server** trước, sau đó khởi chạy **Client**.
4. Nhập tin nhắn, gửi file hoặc icon để trải nghiệm.

---

## Lưu ý

- Đảm bảo cả **Server** và **Client** sử dụng cùng một cổng để giao tiếp.
- Nếu xảy ra lỗi gửi ảnh, hãy kiểm tra buffer size trong cấu hình socket.
