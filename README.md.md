<img src="https://webassets.telerikacademy.com/images/default-source/logos/telerik-academy.svg)" alt="logo" width="300px" style="margin-top: 20px;"/>

# OOP Teamwork Assignment <br><br> Team 3 Work Item Management Application

### Members:

- **Angel Yankov**
- **Emil Nenchev**

<p align="center">
[**Click Here**](https://trello.com/b/Sc7mNDKM) for our <img src="https://productivetihube.files.wordpress.com/2019/12/trello-logo-1.png" width="8%"/> board

## Project Description
This is a Work Item Management (WIM) Console Application. This application supports multiple teams. Each team has name, members, and boards. You can create different work items such as Bug, Story and Feedback you can assign them in different boards and teams and to specific members. Each operation that is performed logs information on a database and you can access all of the activity history of the teams, members, boards and work items. 
<br><br>

## Functional Requirements
 Member has name, list of work items and activity history.

- Name should be unique in the application
- Name is a string between 5 and 15 symbols.

Board has name, list of work items and activity history.

- Name should be unique in the team
- Name is a string between 5 and 10 symbols.

There are 3 types of work items: bug, story, and feedback.

### Bug
Bug has ID, title, description, steps to reproduce, priority, severity, status, assignee, comments, and
history.

- Title is a string between 10 and 50 symbols.
- Description is a string between 10 and 500 symbols.
- Steps to reproduce is a list of strings.
- Priority is one of the following: High, Medium, Low
- Severity is one of the following: Critical, Major, Minor
- Status is one of the following: Active, Fixed
- Assignee is a member from the team.
- Comments is a list of comments (string messages with author).
- History is a list of all changes (string messages) that were done to the bug.

### Story
Story has ID, title, description, priority, size, status, assignee, comments, and history.

- Title is a string between 10 and 50 symbols.
- Description is a string between 10 and 500 symbols.
- Priority is one of the following: High, Medium, Low
- Size is one of the following: Large, Medium, Small
- Status is one of the following: NotDone, InProgress, Done
- Assignee is a member from the team.
- Comments is a list of comments (string messages with author).
- History is a list of all changes (string messages) that were done to the story.

### Feedback

Feedback has ID, title, description, rating, status, comments, and history.

- Title is a string between 10 and 50 symbols.
- Description is a string between 10 and 500 symbols.
- Rating is an integer.
- Status is one of the following: New, Unscheduled, Scheduled, Done
- Comments is a list of comments (string messages with author).
- History is a list of all changes (string messages) that were done to the feedback.

Note: IDs of work items should be unique in the application i.e. if we have a bug with ID X then
we cannot have Story of Feedback with ID X.
<br><br>

## Operations
Application supports the following operations:

### CreateTeam <team_name>
    Creates new Team.

### CreateBoard <board_name> <team_name>
    Creates new Board in a Team.

### CreateMember <member_name>
    Creates new Member.

### CreateBug <team_name> <board_name> <work_item_id> <title> <priority> <severity> <steps> <description>
    Creates new Bug.

### CreateFeedback <team_name> <board_name> <work_item_id> <title> <rating> <description>
    Creates new Feedback.

### CreateStory <team_name> <board_name> <work_item_id> <title> <priority> <size> <description>
    Creates new Story.

### ChangeBug <work_item_id> <property> <type>
    Changes a Property of a Bug to a desired Type.

    Change options: 
    <properties>  <types>
    <priority> => low/medium/high
    <severity> => minor/major/critical
    <status>   => active/fixed

### ChangeFeedback <work_item_id> <property> <type>
    Changes a Property of a Feedback to a desired Type.

    Change options:
    <properties>   <types>
    <status>    => new/unscheduled/scheduled/done
    <rating>    => 1-10

### ChangeStory <work_item_id> <property> <type>
    Changes a Property of a Story to a desired Type.

    Change options:
    <properties>  <types>
    <priority> => low/medium/high
    <size>     => small/medium/large
    <status>   => notDone/inProgress/done

### AddMember <member_name> <team_name>
    Add a Member to a Team.

### AddComment <work_item_id> <member_name> <comment>
    Add a Comment to a WorkItem by a Member.

### Assign <member_name> <work_item_id>
    Assigns a Member to a WorkItem.

### Unassign <work_item_id>
    Unassigns a WorkItem.

### ShowAllTeams <>
    Shows all Teams.

### ShowAllBoards <team_name>
    Shows all Boards of a Team.

### ShowAllPeople <>
    Shows all Members.

### ShowAllTeammembers <team_name>
    Shows all Members of a Team.

### ShowTeamActivity <team_name>
    Shows all of the activity of a Team.

### ShowBoardActivity <board_name> <team_name>
    Shows all the activity of a Board in a Team.

### ShowPersonActivity <member_name>
    Shows all the activity of a Member.

### ListWorkItems <filter_1> <filter_2> <filter_3> <sort_by>
    Shows a list of WorkItems according to filters or sorting requirements

    <filter_1> => all/bug/story/feedback
    <filter_2> => status value or assignee name
    <filter_3> => assignee name
    <sort_by>  => title/priority/severity/size/rating

    Listing options:
    listworkitems <filter_1>
    listworkitems <filter_1> <filter_2>
    listworkitems <filter_1> <filter_2> <filter_3>
    listworkitems <filter_1> <filter_2> <sort_by>
    listworkitems <filter_1> <filter_2> <filter_3> <sort_by>

### Help
    Shows all available commands and how to write them correctly
<br><br>

## Command Helper

    All available commands for the application

    <Command>               <Arguments>
    <addcomment>            <work_item_id> <member_name> <comment>
    <addmember>             <member_name> <team_name>
    <assign>                <member_name> <work_item_id>
    <unassign>              <work_item_id>
    <changebug>             <work_item_id> <priority/severity/status> <low,medium,high/minor,major,critical/active,fixed>
    <changefeedback>        <work_item_id> <status/rating> <new,unscheduled,scheduled,done/1-10>
    <changestory>           <work_item_id> <priority/size/status> <low,medium,high/small,medium,large/notdone,inprogress,done>	
    <createteam>            <team_name>
    <createboard>           <board_name> <team_name>
    <createmember>          <member_name>
    <createbug>             <team_name> <board_name> <work_item_id> <title> <low/medium/high> <minor/major/critical> <step-step> <description>
    <createfeedback>        <team_name> <board_name><work_item_id> <title> <1-10> <description>
    <createstory>           <team_name> <board_name> <work_item_id> <title> <low/medium/high> <small/medium/large> <description>
    <showallteams>
    <showallboards>         <team_name>
    <showallpeople>
    <showallteammembers>    <team_name>
    <showteamactivity>      <team_name>
    <showboardactivity>	<board_name> <team_name>
    <showpersonactivity>	<member_name>
		                         Filter_1		Filter_2       Filter 3		          Sort_by
    <listworkitems>	        <all/bug/story/feedback>   <status/assignee>  <assignee>   <title/priority/severity/size/rating>
    <help>
