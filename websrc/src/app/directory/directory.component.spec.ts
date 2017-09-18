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

    beforeEach(() => {
        mockHttp = { get: sinon.stub() };
        testObject = new DirectoryComponent(mockHttp);

        mockHttp.get.returns(Observable.of([]));
    });

    describe('init', () => {
        
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
                .withArgs('/api/directory')
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
                .withArgs('/api/directory')
                .returns(Observable.of([]));
                        
            testObject.ngOnInit();

            expect(testObject.people).toEqual([]);
        });

        it('shows loading spinner while retrieving records', (done) => {
            let people: Array<Person> = [
                {
                    name: 'Brian',
                    age: 38,
                    phone: '1111111111',
                    imagePath: 'https://randomuser.me/api/portraits/men/1.jpg',
                    interests: 'soccer & music'
                }
            ];

            mockHttp.get
                .withArgs('/api/directory')
                .returns(Observable.of(people).delay(500));
 
            testObject.ngOnInit();
            
            expect(testObject.loading).toBeTruthy();
            setTimeout(() => {
                expect(testObject.loading).toBeFalsy();
                done();
            }, 1000);
        });
    });

    describe('searchTextChanged', () => {

        it('should retrieve search results from api when text changes', () => {
            
            let people: Array<Person> = [
                {
                    name: 'abe lincoln',
                    age: 160,
                    phone: '186 - 418 - 6418',
                    interests: 'politics',
                    imagePath: '/images/abe.jpg'
                }
            ];

            mockHttp.get
                .withArgs('/api/directory/search?text=abe&skip=0')
                .returns(Observable.of(people));
            
            testObject.searchTextChanged('abe');

            expect(testObject.searchText).toBe('abe');
            expect(testObject.people).toEqual(people);
        });

        it('handles no results', () => {
            let people = [];
            mockHttp.get
                .withArgs('/api/directory/search?text=def&skip=0')
                .returns(Observable.of(people));
                        
            testObject.searchTextChanged('def');
            
            expect(testObject.people).toEqual([]);
        });

        it('shows loading spinner while retrieving records', (done) => {
            mockHttp.get
                .withArgs('/api/directory/search?text=xyz&skip=0')
                .returns(Observable.of([]).delay(500));
 
              testObject.searchTextChanged('xyz');
            
            expect(testObject.loading).toBeTruthy();
            setTimeout(() => {
                expect(testObject.loading).toBeFalsy();
                done();
            }, 1000);
        });
    });

    describe('scrolled', () => {

        it('should load the next set of records', () => {
            testObject.searchText = 'foo';
            testObject.people = [new Person(), new Person(), new Person()];

            let people: Array<Person> = [
                {
                    name: 'foo lincoln',
                    age: 160,
                    phone: '186 - 418 - 6418',
                    interests: 'politics',
                    imagePath: '/images/abe.jpg'
                }
            ];

            mockHttp.get
                .withArgs('/api/directory/search?text=foo&skip=3')
                .returns(Observable.of(people));

            testObject.onScroll();

            expect(testObject.people.length).toBe(4);

            expect(testObject.people[3].name).toBe('foo lincoln');
        });

        it('should load next results when search is undefined', () => {
            testObject.people = [new Person(), new Person(), new Person()];
            
            let people: Array<Person> = [
                {
                    name: 'foo lincoln',
                    age: 160,
                    phone: '186 - 418 - 6418',
                    interests: 'politics',
                    imagePath: '/images/abe.jpg'
                }
            ];

            mockHttp.get
                .withArgs('/api/directory/search?text=&skip=3')
                .returns(Observable.of(people));

            testObject.onScroll();

            expect(testObject.people.length).toBe(4);

            expect(testObject.people[3].name).toBe('foo lincoln');
        });

    });
});
