create database StudyBuddyDB;

create table QuestionAndAnswerDetail (
    QAId int NOT NULL PRIMARY KEY,
    QACategory varchar(50) NOT NULL,
    Question varchar(MAX) NOT NULL,
    Answer varchar(MAX) NOT NULL,
);

create table UserDetail (
    UserId int NOT NULL PRIMARY KEY,
    UserName varchar(50) NOT NULL,
);

create table FavoriteQA (
    FavoriteQAId int NOT NULL PRIMARY KEY,
    UserId int NOT NULL,
	QAId int NOT NULL,
	IsActive bit NOT NULL
);


insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (1,
			'Angular','What is Angular and how is it different from Angular JS?',
			'Angular is an open sourced, front end web framework that allows for easy development of web-based applications and SPAs. While AngularJS supports a MVC design model, Angular uses components and directives, AngularJS is JavaScript based while Angular is TypeScript based, AngularJS does not provide any mobile support while Angular does, AngularJS does not support dependency injection, and two-way databinding with AngularJS slows down the speed of an application, whereas Angular is a lot faster.');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (2,
			'Angular','What are the advantages of using Angular?',
			'It supports two-way databinding. It follows MVC architectural pattern. You can create custom directives. It supports RESTful services. Validationsare supported. Client and server communication is facilitated');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (3,
			'Angular','What is Angular and how is it different from Angular JS?',
			'It supports two-way databinding. It follows MVC architectural pattern. You can create custom directives. It supports RESTful services. Validationsare supported. Client and server communication is facilitated');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (4,
			'Angular','What is Angular mainly used for?',
			'It is typically used for the development of SPAs. Angular has a set of ready-to-use modules for SPAs, and has features like built-in data streaming, type checking, and a modular CLI');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (5,
			'Angular','What are Angular expressions?',
			'They are code snippets that are placed in double curly bracket binding. We use these to bind application data to HTML');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (6,
			'Angular','What are templates in Angular?',
			'Templates in Angular are written with HTML that contains Angular-specific elements and attributes. These templates are combined with information coming from the model and controller which are further rendered to provide the dynamic view to the user.');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (7,
			'Angular','What is string interpolation?',
			'A special syntax that uses template expressions within double curly braces for displaying the component data, and embedding it into the HTML code.');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (8,
			'Angular','What are controllers in Angular?',
			'They are JavaScript functions which provide data and logic to a template UI. They control how data flows from the server to the view');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (9,
			'Angular','What are directives in Angular?',
			'They are functions within the HTML that manipulate DOM elements whenever Angular compiles them. There are three types: components, attribute, and structural. Attribute directives let you alter the properties of an element. Structural directives change the layout by adding or removing elements from the DOM.');
insert into QuestionAndAnswerDetail (QAId, QACategory, Question, Answer) 
	values (10,
			'Angular','What is the purpose of a filter in Angular?',
			'Filters in Angular are used for formatting the value of an expression in order to display it to the user. These filters can be added to the templates, directives, controllers or services. Not just this, you can create your own custom filters. Using them, you can easily organize data in such a way that the data is displayed only if it fulfills certain criteria. Filters are added to the expressions by using the pipe character |, followed by a filter.');

insert into UserDetail (UserId, UserName) values (1,'Sonia');
insert into UserDetail (UserId, UserName) values (2,'Jake');
insert into UserDetail (UserId, UserName) values (3,'Lonnie');


insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (1,1,1,1);
insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (2,2,1,1);
insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (3,3,1,1);

insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (4,1,2,1);
insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (5,2,2,1);
insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (6,3,2,1);

insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (7,1,3,1);
insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (8,2,3,1);
insert into FavoriteQA (FavoriteQAId, UserId, QAId, IsActive) values (9,3,3,1);


