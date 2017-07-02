# generic-repository-asp-mvc
A project base that built on top of MVC architecture

# Tiers
 1) AppCore
 2) Core.Entity
 3) Core.Common
 4) Core.Contract
 5) Core.Model
 6) Core.Business
 7) Core.Repository
 8) Core.Utility
 9) Core.MVC
 
 # AppCore
  AppCore basically stores Enums which are used globally on the project.
   - Result Types: are used for defining a result as method output which is either Successful or Failed or NoData at all.
   - Status Types: are used for defining a status of an entity.
   - Parameter Types: are used for defining system parameter to use globally on the projects.
   - Results: is used for defining a return objects at once as a method output.
   ----------------------------------------------------------------------------------------------------------------------------------------
    
# Core.Entity
Core.Entity basically defines base of entities. Methods, Results and EF Code First classes are using Entity to gather all in one managable place. Also Core.Entity has pre build entity classes. For example; System Users, System Roles, Roles and Premission, User Roles etc.

 - IEntity: is an interface that populates `Entities`. IEntity has two properties which are ID and Status. ID is a primary key of all Entities.
 - IEntityHistorical : is an interface that populates `EntityHistorical`. IEntityHistorical has same properties as the IEntity but also gives you to ability store basic Logs. For example; CreatedDate, CreatedBy, LastModifiedBy etc.
 - Entity: is a class which consumes IEntity and used in the entire framework as a delimeter.
 - EntityHistorical: is a class which consumes both IEntityHistorical and Entity and used for when loging is needed.
 - ChangeLog: is a pre defined entity and lets you store changes.
 - SystemUsers: is a pre defined entity and lets you create users who will use and manage system.
 - SystemRoles: is a pre defined entity and lets you create roles for SystemUsers.
 - SystemControllerActions: is a pre defined entity and lets you store Controllers and its Actions which uses `BaseController` as base.
 - UserRoles: is a pre defined many-to-many entity and lets you assign Roles to Users.
 - RolePermission: is a pre defined many-to-many entity and lets you create boundries for your SystemRoles with using SystemControllerAction.
------------------------------------------------------------------------------------------------------------------------------------------
# Core. Common
Core.Common basically stores Global Variables and Global Methods that are used in the entire framework. Such as Root Folder, User Session Name etc.

 - Global Variables: Has ConnectionStringName for EF Code First, AppStartupPath to get path of the application, RootFolder to get root folder and UserSession to define a session in Controllers.
 - GlobalMethods: Has GetDBContext for creating instace of a BaseDbContext in runtime. It finds the model of the given entity and creates a instace of that model. With this method you can define more than one model for your project and use the framework as a base operator.
----------------------------------------------------------------------------------------------------------------------------------------
Installation and Usage will be added soon!
