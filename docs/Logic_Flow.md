## 5. مخططات التدفق المنطقي (Logic Flowcharts)

الأداة المستخدمة في الرسم: تم تصميم وإعداد المخططات التدفّقية باستخدام أداة Mermaid.js المعتمدة على الشفرة البرمجية (Diagrams-as-Code).

---

### المخطط الأول: إجراءات التدقيق وإغلاق الملف المالي النهائي عند الخروج

```mermaid
graph TD
    %% تعريف العناصر والخطوات
    Start([استقبال إشعار موعد الخروج المتوقع <br> Module 3 - قبل 24 ساعة])
    Scan[عمل مسح وتدقيق لجميع الخدمات في <br> الأنظمة الأخرى صيدلية، عمليات، إقامة]
    Decision{هل توجد خدمات معلقة أو غير مسجلة؟}
    Block[منع إغلاق الملف المالي وإرسال تنبيه <br> بالقسم المتأخر]
    Wait[انتظار معالجة وتسوية الخدمات <br> المعلقة من القسم المعني]
    Connect[الارتباط مع شركة التأمين وحساب <br> التغطية النهائية]
    Show[إظهار المبلغ الصافي المتبقي على <br> المريض]
    Collect[تحصيل المبلغ المتبقي من المريض - <br> دفع مباشر]
    Invoice[إصدار الفاتورة النهائية الموحدة للمريض]
    Close[تغيير حالة الملف المالي للمريض إلى <br> مغلق]
    Send[إرسال إشعار ببراءة الذمة المالية لنظام <br> القبول والإقامة]
    End([نهاية الإجراء: المريض خارج المستشفى])

    %% الربط المنطقي بين الخطوات
    Start --> Scan
    Scan --> Decision
    Decision -- نعم --> Block
    Block --> Wait
    Wait --> Scan
    Decision -- لا --> Connect
    Connect --> Show
    Show --> Collect
    Collect --> Invoice
    Invoice --> Close
    Close --> Send
    Send --> End

    %% تعيين الألوان
    style Start fill:#f9f,stroke:#333,stroke-width:2px
    style End fill:#d5e8d4,stroke:#82b366,stroke-width:2px
    style Decision fill:#fff2cc,stroke:#d6b656,stroke-width:2px
    style Block fill:#f8cecc,stroke:#b85450,stroke-width:2px
    style Invoice fill:#d5e8d4,stroke:#82b366,stroke-width:2px
    style Scan fill:#fff,stroke:#333,stroke-width:1px
    style Wait fill:#fff,stroke:#333,stroke-width:1px
    style Connect fill:#fff,stroke:#333,stroke-width:1px
    style Show fill:#fff,stroke:#333,stroke-width:1px
    style Collect fill:#fff,stroke:#333,stroke-width:1px
    style Close fill:#fff,stroke:#333,stroke-width:1px
    style Send fill:#fff,stroke:#333,stroke-width:1px
