import * as sinon from 'sinon';
import { DirectoryComponent } from './directory.component';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import 'rxjs/add/observable/throw';
import { Person } from "./person";

describe('DirectoryComponent', () => {
    let testObject: DirectoryComponent;
    let mockHttp: any;  
    describe('init', () => {
        
        beforeEach(() => {
            mockHttp = { get: sinon.stub() };
            testObject = new DirectoryComponent(mockHttp);
        });

        it('should get records from api', () => {
            let people = <Array<Person>>[
                {
                    name: 'Brian',
                    age: 38,
                    phone: '1111111111',
                    imagePath: 'https://randomuser.me/api/portraits/men/1.jpg',
                    interests: 'soccer & music'
                }
            ];
            mockHttp.get
                .withArgs('/api/directory?skip=0')
                .returns(Observable.of(people));
            
            let originalPeople = testObject.people;
            
            testObject.ngOnInit();

            let firstPerson = testObject.people[0];
            
            expect(originalPeople).toBe(testObject.people);
            expect(testObject.people.length).toBe(1);
            expect(firstPerson.name).toBe('Brian');
            expect(firstPerson.age).toBe(38);
            expect(firstPerson.phone).toBe('1111111111');
            expect(firstPerson.interests).toBe('soccer & music');
            expect(firstPerson.imagePath).toBe('https://randomuser.me/api/portraits/men/1.jpg');
        });

        it('handles no results', () => {
            mockHttp.get
                .withArgs('/api/directory?skip=0')
                .returns(Observable.of([]));
                        
            testObject.ngOnInit();

            expect(testObject.people).toBe([]);
        });

        it('shows loading spinner while retrieving records', (done) => {
            let people = <Array<Person>>[
                {
                    name: 'Brian',
                    age: 38,
                    phone: '1111111111',
                    imagePath: 'https://randomuser.me/api/portraits/men/1.jpg',
                    interests: 'soccer & music'
                }
            ];
            
             mockHttp.get
                .withArgs('/api/directory?skip=0')
                .returns(Observable.of(people).delay(1000));

             testObject.ngOnInit();
            
             expect(testObject.loading).toBeTruthy();
            
             setTimeout(() => {
                 expect(testObject.loading).toBeFalsy();
                 done();
             }, 3000);
        });

    });
});
