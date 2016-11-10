import {autoinject} from 'aurelia-framework';    
import {HttpClient} from 'aurelia-fetch-client';

@autoinject()
export class Driver {
    private http: HttpClient;
    private drivers: DriverDto[];

    constructor(http: HttpClient) {
        this.http = http;

        this.http.fetch('http://localhost:5000/drivers.json')
        .then(response => response.json())
        .then(data => {
            this.drivers = <DriverDto[]> data;
        });
    }

}

export class DriverDto {
    public hostname: string;
    public driver: string;
}