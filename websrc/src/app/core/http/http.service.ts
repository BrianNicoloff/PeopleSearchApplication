import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Http, Response, RequestOptions, Headers } from '@angular/http';

@Injectable()
export class HttpService {

   constructor(private http: Http) { }

    get<T>(url: string): Observable<T> {
        return this.http.get(url)
            .map(this.extractData)
            .catch(this.handleHttpError.bind(this));
    }

    ///////

    private extractData(res: Response) {
        const body = res.json();
        return body || {};
    }

    private handleHttpError<T>(res: Response): Observable<T> | string {
        return Observable.throw(res.json().exceptionMessage) || 'server error';
    }
}
