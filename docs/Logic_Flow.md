```mermaid
graph TD
    %% تعريف خط البداية الأول: التحقق اليومي من الخدمات
    Start1([بداية: طلب خدمة للمريض من قسم آخر صيدلية، عمليات، إقامة]) --> VerifyID[التحقق من الهوية الطبية الرقمية للمريض عبر نظام القبول - Module 1]
    VerifyID --> CheckCoverage{هل توجد تغطية تأمينية كافية أو دفع مباشر مسبق؟}
    
    %% مسار رفض الخدمة
    CheckCoverage -- لا --> DenyService[حظر تقديم الخدمة وإظهار تنبيه مالي في القسم الطالب]
    DenyService --> End1([نهاية الإجراء: الخدمة مرفوضة])
    
    %% مسار قبول الخدمة وتقييدها تلقائياً
    CheckCoverage -- نعم --> AllowService[السماح بتقديم الخدمة وصرفها للمريض]
    AllowService --> AutoBilling[إرسال تكلفة الخدمة تلقائياً وتقييدها في الفاتورة الموحدة]
    AutoBilling --> End2([نهاية الإجراء: تحديث الحساب المالي في الوقت الفعلي])

    %% تعريف خط البداية الثاني: إجراءات الخروج وإغلاق الملف
    Start2([بداية: استقبال إشعار موعد الخروج المتوقع قبل 24 ساعة - Module 3]) --> ScanSystems[عمل مسح وتدقيق لجميع الخدمات في الأنظمة الأخرى صيدلية، عمليات، إقامة]
    ScanSystems --> CheckPending{هل توجد خدمات معلقة أو غير مسجلة في الأقسام؟}
    
    %% مسار وجود خدمات معلقة (إغلاق الملف محظور)
    CheckPending -- نعم --> BlockDischarge[منع إغلاق الملف المالي وإرسال تنبيه بالقسم المتأخر لإدخال بياناته]
    BlockDischarge --> ScanSystems
    
    %% مسار اكتمال تسجيل الخدمات (متابعة التصفية)
    CheckPending -- لا --> FetchInsurance[الارتباط مع واجهة شركة التأمين وحساب التغطية النهائية آلياً]
    FetchInsurance --> CalculateNet[إظهار المبلغ الصافي المتبقي على المريض بعد خصم التأمين]
    CalculateNet --> CollectPayment[تحصيل المبلغ المتبقي من المريض عبر الدفع المباشر]
    CollectPayment --> GenerateInvoice[إصدار الفاتورة النهائية الموحدة للمريض]
    GenerateInvoice --> CloseFile[تغيير حالة الملف المالي للمريض في النظام إلى مغلق Closed]
    CloseFile --> NotifyAdmission[إرسال إشعار إلكتروني ببراءة الذمة المالية لنظام القبول والإقامة]
    NotifyAdmission --> EndDischarge([نهاية الإجراء: المريض مبرأ ذمته ومستعد للخروج الفعلي])

    %% تنسيق الألوان والمظهر الاحترافي للمخطط
    style Start1 fill:#E1BEE7,stroke:#4A148C,stroke-width:2px
    style Start2 fill:#E1BEE7,stroke:#4A148C,stroke-width:2px
    style End1 fill:#FFCDD2,stroke:#B71C1C,stroke-width:2px
    style End2 fill:#C8E6C9,stroke:#1B5E20,stroke-width:2px
    style EndDischarge fill:#C8E6C9,stroke:#1B5E20,stroke-width:2px
    style CheckCoverage fill:#FFF9C4,stroke:#F57F17,stroke-width:2px
    style CheckPending fill:#FFF9C4,stroke:#F57F17,stroke-width:2px
    style BlockDischarge fill:#FFCDD2,stroke:#B71C1C,stroke-width:2px
    style AutoBilling fill:#BBDEFB,stroke:#0D47A1,stroke-width:2px
    style GenerateInvoice fill:#C8E6C9,stroke:#1B5E20,stroke-width:2px
