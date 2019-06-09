export class Response<T>{
    constructor(public code?: number,
        public error?: Error,
        public data?: T) {}
}