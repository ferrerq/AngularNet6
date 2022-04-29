import { AlertService } from './alert.service';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError as observableThrowError, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { Optional } from '@angular/core';


export abstract class HttpService<T> {

    // Default HTTP header
    protected defaultHeader: HttpHeaders | undefined;


    public constructor(public httpClient: HttpClient,
        public restApi: string,
        public alert: AlertService) {
            


    }

    public getById(id: number | string): Observable<T> {
        return this.httpClient.get<T>(this.restApi.concat('/', String(id)), { headers: this.defaultHeader, withCredentials: true }).pipe(
            retry(0),
            catchError(this.handleError)
        );
    }

    public get(params?: HttpParams): Observable<T[]> {
        return this.httpClient.get<T[]>(this.restApi, { params}).pipe(
            retry(0),
            catchError(this.handleError)
        );
    }

    public getPropertiesFromObject(id: number | string, propertieName: string,
        tableName?: string, values?: string[], params?: HttpParams): Observable<T> {
        let querystring: string = this.restApi.concat('/', String(id) + '/' + propertieName);
        if (tableName != null && values != null) {
            querystring += querystring = '?';
            values.forEach(item => {
                querystring += querystring = `${tableName}=${item}&`;
            });
        }

        return this.httpClient.get<T>(querystring, { params, headers: this.defaultHeader, withCredentials: true }).pipe(
            retry(0),
            catchError(this.handleError)
        );
    }

    public post(object: any): Observable<T> {
        return this.httpClient.post<T>(this.restApi, object)
            .pipe(
                retry(0),
                catchError(this.handleError)
            );
    }


    public postPropertiesOfObject(id: number | string, propertieName: string, object: any): Observable<T> {
        const body = JSON.stringify(object);
        return this.httpClient.post<T>(this.restApi.concat('/', String(id) + '/' +
            propertieName), body, { headers: this.defaultHeader, withCredentials: true })
            .pipe(
                retry(0),
                catchError(this.handleError)
            );
    }


    public put(object: any): Observable<T> {
        return this.httpClient.put<T>(this.restApi, object, { headers: this.defaultHeader, withCredentials: true })
            .pipe(
                retry(0),
                catchError(this.handleError)
            );
    }



    public putPropertiesOfObject(id: number | string, propertieName: string, object: any): Observable<T> {
        const body = JSON.stringify(object);
        return this.httpClient.put<T>(this.restApi.concat('/', String(id) + '/' +
            propertieName), body, { headers: this.defaultHeader, withCredentials: true })
            .pipe(
                retry(0),
                catchError(this.handleError)
            );
    }

    // tslint:disable-next-line:no-reserved-keywords
    public delete(id: number | string): Observable<T> {
        return this.httpClient.delete<T>(this.restApi.concat('/', String(id)), { headers: this.defaultHeader, withCredentials: true })
            .pipe(
                retry(0),
                catchError(this.handleError)
            );
    }

    private handleError = (exception: any): Observable<never> => {
        switch (exception.status) {
            case 0:
                this.alert.showErrorToast('Api ERROR', 'Unable to connect to the API');
                break;
            default:
                this.alert.showInfoToast(exception.statusText, exception.message);
        }

        const msg = `Error status code ${exception.status} at ${exception.url}`;
        return  throwError(()=> new Error(msg));
    }


}
