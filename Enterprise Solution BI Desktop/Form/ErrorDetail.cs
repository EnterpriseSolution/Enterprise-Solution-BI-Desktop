using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace EnterpriseSolutionBIDesktop
{    
    public sealed class ErrorDetail
    {
        private Exception _exception;
        private string _errorMessage;
        private string _technicalDetails;
        private bool _translateErrorMessage;

        public Exception Exception
        {
            get { return _exception; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public string TechnicalDetails
        {
            get { return _technicalDetails; }
        }

        public ErrorDetail(Exception exception)
        {
            _exception = exception;
            Initialize();
        }

        public ErrorDetail(Exception exception, bool translateErrorMessage)
        {
            _exception = exception;
            _translateErrorMessage = translateErrorMessage;
            Initialize();
        }

        private void Initialize()
        {
            if (_exception == null) return;

            try
            {
                Exception exception = _exception;
                StringBuilder errorMessage = new StringBuilder();
                StringBuilder technicalDetails = new StringBuilder();

                if (exception.InnerException != null && exception.InnerException is AppException)
                {
                    exception = exception.InnerException;
                }

                AppException generalException = _exception as AppException;
                string message = (_translateErrorMessage ? exception.Message : exception.Message);
                string nonTranslatedMessage = exception.Message;
                object data = null;

                if (generalException != null)
                {
                    //if (generalException.Args != null)
                    //{
                    //    message = string.Format(message, generalException.Args);
                    //    nonTranslatedMessage = string.Format(nonTranslatedMessage, generalException.Args);
                    //}

                    //if (generalException.InvalidData != null && generalException.InvalidData.Count > 0)
                    //{
                    //    StringBuilder sb = new StringBuilder();

                    //    foreach (object item in generalException.InvalidData)
                    //    {
                    //        if (sb.Length > 0) sb.Append(", ");
                    //        sb.Append(item);
                    //    }

                    //    data = sb.ToString();
                    //}
                }

                errorMessage = errorMessage.Append(message);
                errorMessage = errorMessage.Replace("\n", "\r\n");

                technicalDetails.Append(string.Format("Date: {0} {1}\r\n", DateTime.Today.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                technicalDetails.Append(string.Format("Version: {0} ({1})\r\n", "5.1", File.GetLastWriteTime(typeof(Program).Assembly.Location)));
                technicalDetails.Append(string.Format("Source: {0}\r\n", exception.Source));
                technicalDetails.Append(string.Format("Class: {0}\r\n", (exception.TargetSite != null ? exception.TargetSite.DeclaringType.ToString() : null)));
                technicalDetails.Append(string.Format("Member Type: {0}\r\n", (exception.TargetSite != null ? exception.TargetSite.MemberType.ToString() : null)));
                technicalDetails.Append(string.Format("Member Name: {0}\r\n", exception.TargetSite));
                technicalDetails.Append(string.Format("Data: {0}\r\n", data));
                technicalDetails.Append("\r\n");
                technicalDetails.Append(string.Format("Exception: {0}\r\n{1}", nonTranslatedMessage, exception.StackTrace));

                int innerExceptionCount = 1;
                string innerMessage = string.Empty;
                Exception innerException = exception.InnerException;
                while (innerException != null)
                {
                    if (string.CompareOrdinal(innerMessage, innerException.Message) == 0) break;

                    innerMessage = innerException.Message;
                    generalException = innerException as AppException;
                    //if (generalException != null && generalException.Args != null)
                    //{
                    //    innerMessage = string.Format(innerMessage, generalException.Args);
                    //}

                    technicalDetails.Append(string.Format("\r\n\r\nInner Exception {0}: {1}\r\n{2}", innerExceptionCount, innerMessage, innerException.StackTrace));

                    innerExceptionCount++;
                    innerException = innerException.InnerException;
                }

                if (exception is ReflectionTypeLoadException)
                {
                    int loaderExceptionCount = 1;
                    ReflectionTypeLoadException reflectionTypeLoadException = (ReflectionTypeLoadException)exception;
                    foreach (Exception loaderException in reflectionTypeLoadException.LoaderExceptions)
                    {
                        technicalDetails.Append(string.Format("\r\n\r\nLoader Exception {0}: {1}\r\n{2}", loaderExceptionCount, loaderException.Message, loaderException.StackTrace));
                        loaderExceptionCount++;
                    }
                }

                if (data != null && !string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    errorMessage.Append(string.Format("\r\n{0}: {1}",(_translateErrorMessage ? "Data" : "Data"), data.ToString().Trim()));
                }

                _errorMessage = errorMessage.ToString();
                _technicalDetails = technicalDetails.ToString();
            }
            catch
            {
                _errorMessage = _exception.Message;
                _technicalDetails = _exception.StackTrace;
            }
        }
    }
}
