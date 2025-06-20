import React, { useEffect, useState } from 'react'

const EventList = () => {
    const [events, setEvents] = useState([])
const getEvents = async () => {
  const res = await fetch ("https://eventservice-euchhwdpc9evgcdp.swedencentral-01.azurewebsites.net/api/Events")

  if (res.ok) {
    const response = await res.json()
    SetEvents(response.result)
  }
}


    useEffect(() => {
        getEvents()
    }, [])
  

  return (
    <section id="events">
      {
        events.map(events => (<EventItem key={event.id} item={event}/> ))
      }
    </section>
  )
}

export default EventList


