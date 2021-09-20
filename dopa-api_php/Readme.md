DOPA Citizen Profile

- ใช้ external library 3 ตัว คือ
-- Apache Commons Logging => http://commons.apache.org/proper/commons-logging/
-- Apache Httpcomponents => https://hc.apache.org/
-- Google Gson => https://github.com/google/gson
- ไฟล์ตัวอย่างอยู่ที่ th.or.ega.client.SimpleEGAWSClient
- สามารถใช้กับ Java 1.7 ขึ้นไปเท่านั้น เนื่องจาก WS Server ได้ Disable SSL Protocol ไปแล้วเพื่อความปลอดภัย ทำให้ Java ที่ Version ต่ำกว่าไม่สามารถใช้งานได้ เพราะตัว API ไม่ Support TLS Protocol ในขั้นตอนของการทำ SSL handshake

ในการเข้าถึง API นี้ ท่านต้องได้รับความยินยอมจากกรมการปกครองก่อนจึงจะใช้งานได้ กรุณาติดต่อ สำนักบริหารการทะเบียน กรมการปกครอง (http://www.bora.dopa.go.th/index.php/th/) เพื่อขอข้อมูลเพิ่มเติม

Source: https://sc.dga.or.th/tutorials/dopa-api_php/
