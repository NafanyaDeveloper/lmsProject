export class Participant{
    constructor(public userId?: string,
        userName?: string,
        participantRoleId?: string,
        roleName?: string,
        public groupId?: string,
        groupName?: string) {}
}