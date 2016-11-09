import {autoinject} from 'aurelia-framework';    
import {HttpClient} from 'aurelia-fetch-client';

@autoinject()
export class Driver {
    private http: HttpClient;

    constructor(http: HttpClient) {
        this.http = http;

    }

}

export class DriverDto {
    public hostname: string;
    public name: string;
}