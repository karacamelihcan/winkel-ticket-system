using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinkelTicket.Contract.Response
{
    public class ServiceResponse <T> where T : class 
    {
        public T Data { get; set; }
        public bool IsSuccessfull { get; set; }
        public ErrorResponse Error { get; set; }

        public static ServiceResponse<T> Success(T Data){
            return new ServiceResponse<T>{
                Data = Data,
                IsSuccessfull = true
            };
        }
        public static ServiceResponse<T> Success(){
            return new ServiceResponse<T>{
                Data = default,
                IsSuccessfull = true
            };
        }
        public static ServiceResponse<T> Fail(ErrorResponse error){
            return new ServiceResponse<T>{
                Error = error,
                IsSuccessfull = false,
            };
        }
        public static ServiceResponse<T> Fail(string errorMsg){
            var errorResponse = new ErrorResponse(errorMsg);
            return new ServiceResponse<T>{
                Error = errorResponse,
                IsSuccessfull = false
            };
        }

    }
}