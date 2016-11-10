import {autoinject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {Driver} from 'src/driver';

@autoinject()
export class Laptimes {
    private http: HttpClient;
    private laptimes: LaptimeDto[];

    constructor(http: HttpClient) {
        this.http = http;

        this.http.fetch('http://localhost:5000/laptimes.json')
        .then(response => response.json())
        .then(data => {
            this.laptimes = <LaptimeDto[]> data;
        });
    }

}

export class LaptimeDto {
    public id: string;
    public trackName: string;
    public carName: string;
    public carClass: string;
    public time: TimeSpan;
    public recordedBy: Driver;
}

export class TimeSpan {
    public days: number;
    public hours: number;
    public minutes: number;
    public seconds: number;
    public milliseconds: number;

    public toString(): string {
        return "bla";
    }
}