using System;
using System.Reflection;

namespace _5951071113_PhamTruongTruong_Nhom3.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}