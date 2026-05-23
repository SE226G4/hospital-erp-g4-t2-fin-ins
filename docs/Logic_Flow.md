graph TD
    %% تعيين الألوان والأشكال
    classDef startEnd fill:#f9f,stroke:#333,stroke-width:2px,rx:20px,ry:20px;
    classDef process fill:#fff,stroke:#333,stroke-width:1px;
    classDef decision fill:#fff2cc,stroke:#d6b656,stroke-width:1px;
    classDef error fill:#f8cecc,stroke:#b85450,stroke-width:1px;
    classDef success fill:#d5e8d4,stroke:#82b366,stroke-width:1px;

    Start([استقبال إشعار موعد الخروج المتوقع<br>Module 3 - قبل 24 ساعة])
    Scan[عمل مسح وتدقيق لجميع الخدمات في<br>الأنظمة الأخرى صيدلية، عمليات، إقامة]
    Decision{هل توجد خدمات معلقة أو غير مسجلة؟}
    Block[منع إغلاق الملف المالي وإرسال تنبيه<br>بالقسم المتأخر]
    Wait[انتظار معالجة وتسوية الخدمات<br>المعلقة من القسم المعني]
    Connect[الارتباط مع شركة التأمين وحساب<br>التغطية النهائية]
    Show[إظهار المبلغ الصافي المتبقي على<br>المريض]
    Collect[تحصيل المبلغ المتبقي من المريض -<br>دفع مباشر]
    Invoice[إصدار الفاتورة النهائية الموحدة للمريض]
    Close[تغيير حالة الملف المالي للمريض إلى<br>مغلق]
    Send[إرسال إشعار ببراءة الذمة المالية لنظام<br>القبول والإقامة]
    End([نهاية الإجراء: المريض خارج المستشفى])

    class Start startEnd;
    class Scan process;
    class Decision decision;
    class Block error;
    class Wait process;
    class Connect process;
    class Show process;
    class Collect process;
    class Invoice success;
    class Close process;
    class Send process;
    class End success;

    %% الربط بين الخطوات
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
